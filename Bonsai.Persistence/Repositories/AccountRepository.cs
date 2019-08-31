using System;
using System.Linq;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using BL = Bonsai.Domain;
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

        public BL.UserAccount GetAccountById(long id)
        {
            var account = context.UserAccounts
                .Include(ua => ua.UserData)
                .SingleOrDefault(ua => ua.Id == id);

            return (account != null) ? EntityMapper.ToDomainModel(account) : null;
        }

        public BL.UserAccount CreateAccount(BL.UserAccount account)
        {
            // Validate data

            var dbAccount = EntityMapper.ToDatabaseModel(account);

            passwordHelper.CreatePasswordHashAndSalt(account.Password, out var hash, out var salt);
            dbAccount.PasswordHash = hash;
            dbAccount.PasswordSalt = salt;

            if (dbAccount.UserData == null)
            {
                dbAccount.UserData = new DB.UserData();
            }

            context.UserAccounts.Add(dbAccount);
            context.UsersData.Add(dbAccount.UserData);

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbAccount);
        }

        public BL.UserAccount UpdatePassword(long id, string newPassword)
        {
            // Validate data

            var dbAccount = context.UserAccounts.SingleOrDefault(ua => ua.Id == id);

            if (dbAccount == null)
            {
                throw new Exception("User account not found!");
            }

            // todo validate

            if (!string.IsNullOrWhiteSpace(newPassword) &&
                !passwordHelper.VerifyPassword(newPassword, dbAccount.PasswordHash, dbAccount.PasswordSalt))
            {
                // Password has changed
                passwordHelper.CreatePasswordHashAndSalt(newPassword, out var hash, out var salt);
                dbAccount.PasswordHash = hash;
                dbAccount.PasswordSalt = salt;
            }

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbAccount);
        }

        public BL.UserAccount UpdateEmail(long id, string newEmail)
        {
            // Validate data

            var dbAccount = context.UserAccounts.SingleOrDefault(ua => ua.Id == id);

            if (dbAccount == null)
            {
                throw new Exception("User account not found!");
            }

            // todo validate

            dbAccount.Email = newEmail;

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbAccount);
        }

        public BL.UserAccount UpdateUserData(long accountId, BL.UserData newUserData)
        {
            // Validate data

            var dbAccount = context.UserAccounts
                .Include(ua => ua.UserData)
                .SingleOrDefault(ua => ua.Id == accountId);

            if (dbAccount == null || dbAccount.UserData == null)
            {
                throw new Exception("User account or data not found!");
            }

            // todo validate

            dbAccount.UserData.FirstName = newUserData.FirstName;
            dbAccount.UserData.LastName = newUserData.LastName;
            dbAccount.UserData.DateOfBirth = newUserData.DateOfBirth;
            dbAccount.UserData.Gender = newUserData.Gender;

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbAccount);
        }

        public BL.UserAccount DeleteAccount(long accountId)
        {
            // Validate data

            var dbAccount = context.UserAccounts.SingleOrDefault(ua => ua.Id == accountId);

            if (dbAccount == null)
            {
                throw new Exception("User account not found!");
            }

            context.UsersData.Remove(dbAccount.UserData);
            context.UserAccounts.Remove(dbAccount);

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbAccount);
        }



    }
}
