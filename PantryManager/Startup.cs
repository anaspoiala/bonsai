using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Bonsai.Helpers;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Helpers;
using Bonsai.Service;
using Bonsai.WebAPI.Helpers;
using Bonsai.WebAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Bonsai
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add Database Context
            services.AddDbContext<PantryDbContext>
                (options => options.UseSqlServer(
                    Configuration.GetConnectionString("PantryManagerDatabase"),
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly("Bonsai.Persistence"))
                );

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Configure JWT authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });

            // Add services
            services.AddSingleton(new PasswordHelper());
            services.AddSingleton(new TokenHelper(appSettings.Secret));

            services.AddScoped<UserInformation>();

            AddScopedImplementations(services, GetTypesInNamespace(
                    typeof(PantryDbContext).Assembly, "Bonsai.Persistence.Repositories"));

            AddScopedImplementations(services, GetTypesInNamespace(
                    typeof(IAccountService).Assembly, "Bonsai.Service"));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseAuthentication();

            //app.Use(async (context, next) =>
            //{
            //    var user = context.RequestServices.GetService<UserAccount>();
            //    //context.User.Claims
            //    user.Id = 14;
            //    user.Email = "injected@test.com";
            //});

            app.UseMiddleware<RequestUserIdMiddleware>();

            app.UseMvc();
        }


        // =====================================================================================================================================


        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
            => assembly.GetTypes()
                .Where(t => t.Namespace != null && t.IsPublic && t.IsClass && t.Namespace.StartsWith(nameSpace))
                .ToArray();

        private void AddScopedImplementations(IServiceCollection services, Type[] types)
        {
            foreach (var repo in types)
            {
                services.AddScoped(repo);
                foreach (var interf in repo.GetInterfaces())
                {
                    services.AddScoped(interf, s => s.GetService(repo));
                }
            }
        }
    }
}
