using System;
using System.Collections.Generic;
using System.Linq;
using Bonsai.Exceptions;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using DB = Bonsai.Persistence.Model;

namespace Bonsai.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private PantryDbContext context;
        private PasswordHelper passwordHelper;

        public AccountRepository(PantryDbContext context, PasswordHelper passwordHelper)
        {
            this.context = context;
            this.passwordHelper = passwordHelper;
        }


        public Domain.UserAccount GetAccountById(long id)
        {
            var account = context.UserAccounts
                .Include(ua => ua.UserData)
                .SingleOrDefault(ua => ua.Id == id);

            return (account != null) ? EntityMapper.ToDomainModel(account) : null;
        }

        public Domain.UserAccount GetAccountByUsername(string username)
        {
            var account = context.UserAccounts
                .Include(ua => ua.UserData)
                .SingleOrDefault(ua => ua.Username == username);

            return (account != null) ? EntityMapper.ToDomainModel(account) : null;
        }

        public bool CheckAccountPassword(long id, string password)
        {
            var account = context.UserAccounts.SingleOrDefault(ua => ua.Id == id);

            if (account == null)
            {
                throw new AccountNotFoundException();
            }

            return passwordHelper.VerifyPassword(password, account.PasswordHash, account.PasswordSalt);
        }

        public Domain.UserAccount CreateAccount(Domain.UserAccount account)
        {
            var newAccount = EntityMapper.ToDatabaseModel(account);
            var newUserData = new DB.Accounts.UserData();
            var newPantry = new DB.Items.Pantry();
            var newMealPlanCalendar = new DB.MealPlans.MealPlanCalendar();
            var newRecipeCatalog = new DB.Recipes.RecipeCatalog();

            // Hash password
            passwordHelper.CreatePasswordHashAndSalt(account.Password, out var hash, out var salt);
            newAccount.PasswordHash = hash;
            newAccount.PasswordSalt = salt;

            // Set user data fields
            newUserData.FirstName = account.UserData?.FirstName ?? "";
            newUserData.LastName = account.UserData?.LastName ?? "";
            newUserData.DateOfBirth = account.UserData?.DateOfBirth ?? DateTime.UtcNow;
            newUserData.Gender = account.UserData?.Gender ?? "";

            // Create Pantry, MealPlanCalendar and RecipeCatalog
            newPantry.Items = new List<DB.Items.PantryItem>();
            newPantry.UserData = newUserData;
            newMealPlanCalendar.MealPlans = new List<DB.MealPlans.MealPlan>();
            newMealPlanCalendar.UserData = newUserData;
            newRecipeCatalog.Recipes = new List<DB.Recipes.Recipe>();
            newRecipeCatalog.UserData = newUserData;

            // Set account fields
            newUserData.Pantry = newPantry;
            newUserData.MealPlanCalendar = newMealPlanCalendar;
            newUserData.RecipeCatalog = newRecipeCatalog;
            newAccount.UserData = newUserData;

            // Add account to database
            context.Pantries.Add(newPantry);
            context.MealPlanCalendars.Add(newMealPlanCalendar);
            context.RecipeCatalogs.Add(newRecipeCatalog);
            context.UsersData.Add(newUserData);
            context.UserAccounts.Add(newAccount);

            // Commit changes and return result
            context.SaveChanges();
            return EntityMapper.ToDomainModel(newAccount);
        }


        public Domain.UserAccount UpdateUserData(long accountId, Domain.UserData newUserData)
        {
            var dbAccount = context.UserAccounts
                .Include(ua => ua.UserData)
                .SingleOrDefault(ua => ua.Id == accountId);

            if (dbAccount == null || dbAccount.UserData == null)
            {
                throw new AccountNotFoundException();
            }

            dbAccount.UserData.FirstName = newUserData.FirstName;
            dbAccount.UserData.LastName = newUserData.LastName;
            dbAccount.UserData.DateOfBirth = newUserData.DateOfBirth;
            dbAccount.UserData.Gender = newUserData.Gender;

            context.SaveChanges();
            return EntityMapper.ToDomainModel(dbAccount);
        }

        public Domain.UserAccount DeleteAccount(long accountId)
        {
            var dbAccount = context.UserAccounts
                .SingleOrDefault(ua => ua.Id == accountId);

            if (dbAccount == null)
            {
                throw new AccountNotFoundException();
            }

            context.UserAccounts.Remove(dbAccount);

            context.SaveChanges();
            return EntityMapper.ToDomainModel(dbAccount);
        }

    }
}
