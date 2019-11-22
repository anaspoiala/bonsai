using System;

using Bonsai.Domain;
using Bonsai.Persistence;
using Bonsai.Validators;
using Bonsai.Exceptions;

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
        private IAccountRepository repository;


        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }


        public UserAccount GetAccountById(long accountId)
        {
            return repository.GetAccountById(accountId);
        }

        public UserAccount GetAccountByUsername(string username)
        {
            return repository.GetAccountByUsername(username);
        }

        public UserAccount CreateAccount(UserAccount account)
        {
            ValidateAcount(account);

            return repository.CreateAccount(account);
        }

        public UserAccount DeleteAccount(long accountId)
        {
            return repository.DeleteAccount(accountId);
        }

        public UserAccount UpdateAccountData(long accountId, UserData data)
        {
            return repository.UpdateUserData(accountId, data);
        }

        public bool CheckPassword(long accountId, string password)
        {
            return repository.CheckAccountPassword(accountId, password);
        }

        private void ValidateAcount(UserAccount account)
        {
            ValidateUsername(account.Username);
            ValidatePassword(account.Password);
            ValidateEmail(account.Email);
        }

        private void ValidateUsername(string username)
        {
            if (repository.GetAccountByUsername(username) != null)
            { // Username already exists in the database.
                throw new ValidationException("Username already exists!");
            }

            if (TextValidator.IsNullEmptyOrWhiteSpace(username))
            { // Username empty or not provided.
                throw new ValidationException("Username can't be empty!");
            }

            if (!TextValidator.ContainsBetweenXAndYCharacters(username, 8, 32))
            { // Username doesn't contain between 8 and 32 characters.
                throw new ValidationException("Username must contain between 8 and 32 characters!");
            }

            if (!TextValidator.ContainsLetters(username))
            {  // Username doesn't contain any letters (only numbers or symbols).
                throw new ValidationException("Username must contain at least one letter!");
            }


        }

        private void ValidatePassword(string password)
        {
            if (TextValidator.IsNullEmptyOrWhiteSpace(password))
            { // Password empty or not provided.
                throw new ValidationException("Password can't be empty!");
            }

            if (!TextValidator.ContainsLowerLetters(password) || !TextValidator.ContainsUpperLetters(password))
            { // Password doesn't contain both uppercase and lowercase letters.
                throw new ValidationException("Password must contain both uppercase and lowecase letters!");
            }

            if (!TextValidator.ContainsNumbers(password) && !TextValidator.ContainsSymbols(password))
            { // Pasword doesn't contain neither numbers nor symbols.
                throw new ValidationException("Password must contain at least one number or symbol!");
            }

            if (!TextValidator.ContainsBetweenXAndYCharacters(password, 8, 32))
            { // Password doesn't have between 8 and 32 characters length.
                throw new ValidationException("Password must contain between 8 and 32 characters!");
            }
        }

        private void ValidateEmail(string email)
        {
            if (TextValidator.IsNullEmptyOrWhiteSpace(email))
            { // Email empty or not provided.
                throw new ValidationException("Email can't be empty!");
            }

            if (!TextValidator.HasEmailFormat(email))
            {  // Email must have the "something@email.anything" format.
                throw new ValidationException("Email doesn't have a correct format (something@email.something)!");
            }
        }
    }
}
