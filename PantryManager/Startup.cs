using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Bonsai.Persistence.Context;
using System.Reflection;
using Bonsai.Service;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<PantryDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("PantryManagerDatabase")));

            AddSingletonImplementations(services,
                GetTypesInNamespace(
                    typeof(PantryDbContext).Assembly, 
                    "Bonsai.Persistence.Repositories"));

            AddSingletonImplementations(services,
                GetTypesInNamespace(
                    typeof(IAccountService).Assembly,
                    "Bonsai.Service"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
            => assembly.GetTypes()
                .Where(t => t.Namespace != null && t.IsPublic && t.IsClass && t.Namespace.StartsWith(nameSpace))
                .ToArray();

        private void AddSingletonImplementations(IServiceCollection services, Type[] types)
        {
            foreach (var repo in types)
            {
                services.AddSingleton(repo);
                foreach (var interf in repo.GetInterfaces())
                {
                    services.AddSingleton(interf, s => s.GetService(repo));
                }
            }
        }
    }
}
