using System;

using Bonsai.Domain;
using Bonsai.Persistence;
using Bonsai.Validators;

namespace Bonsai.Service
{
    public interface IAccountService
    {
        UserAccount GetAccountById(long accountId);
        UserAccount GetAccountByUsername(string username);
        UserAccount CreateAccount(UserAccount account);
        UserAccount DeleteAccount(long accountId);
        UserAccount UpdateAccountData(long accountId, UserData data);
        bool CheckPassword(long accountId, string password);
    }

    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;


        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        public UserAccount GetAccountById(long accountId)
        {
            return accountRepository.GetAccountById(accountId);
        }

        public UserAccount GetAccountByUsername(string username)
        {
            return accountRepository.GetAccountByUsername(username);
        }

        public UserAccount CreateAccount(UserAccount account)
        {
            ValidateAcount(account);

            return accountRepository.CreateAccount(account);
        }


        public UserAccount DeleteAccount(long accountId)
        {
            return accountRepository.DeleteAccount(accountId);
        }


        public UserAccount UpdateAccountData(long accountId, UserData data)
        {
            return accountRepository.UpdateUserData(accountId, data);
        }

        public bool CheckPassword(long accountId, string password)
        {
            return accountRepository.CheckAccountPassword(accountId, password);
        }



        private void ValidateAcount(UserAccount account)
        {
            ValidateUsername(account.Username);
            ValidatePassword(account.Password);
            ValidateEmail(account.Email);
        }

        private void ValidateUsername(string username)
        {
            if (accountRepository.GetAccountByUsername(username) != null)               // Username already exists in the database.
            {
                throw new Exception("Username already exists!");
            }

            if (AccountValidator.IsNullEmptyOrWhiteSpace(username) ||                   // Username empty or not provided.
                !AccountValidator.ContainsBetweenXAndYCharacters(username, 8, 32) ||    // Username doesn't contain between 8 and 32 characters.
                !AccountValidator.ContainsLetters(username))                            // Username doesn't contain any letters (only numbers or symbols).
            {
                throw new Exception("Username invalid!");
            }
        }

        private void ValidatePassword(string password)
        {
            if (AccountValidator.IsNullEmptyOrWhiteSpace(password) ||                   // Pasword empty or not provided.
                !AccountValidator.ContainsLowerLetters(password) ||                     // Password must contain between 12-32 character, lower and upper
                !AccountValidator.ContainsUpperLetters(password) ||                     // letters, numbers and symbols.
                !AccountValidator.ContainsNumbers(password) ||
                !AccountValidator.ContainsSymbols(password) ||
                !AccountValidator.ContainsBetweenXAndYCharacters(password, 12, 32))
            {
                throw new Exception("Invalid password!");
            }
        }

        private void ValidateEmail(string email)
        {
            if (AccountValidator.IsNullEmptyOrWhiteSpace(email) ||                      // Email empty or not provided.
                !AccountValidator.HasEmailFormat(email))                                // Email must have the "something@email.anything" format.
            {
                throw new Exception("Invalid email!");
            }
        }
    }
}
