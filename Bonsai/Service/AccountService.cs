using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bonsai.Domain;
using Bonsai.Persistence;

namespace Bonsai.Service
{
    public interface IAccountService
    {
        UserAccount GetAccount(long accountId);
        UserAccount CreateAccount(UserAccount account);
        UserAccount DeleteAccount(long accountId);
        UserAccount UpdateAccountPassword(long accountId, string password);
        UserAccount UpdateAccountEmail(long accountId, string email);
        UserAccount UpdateAccountData(long accountId, UserData data);
    }

    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;


        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        public UserAccount GetAccount(long accountId)
        {
            return accountRepository.GetAccountById(accountId);
        }

        public UserAccount CreateAccount(UserAccount account)
        {
            return accountRepository.CreateAccount(account);
        }

        public UserAccount DeleteAccount(long accountId)
        {
            return accountRepository.DeleteAccount(accountId);
        }

        public UserAccount UpdateAccountPassword(long accountId, string password)
        {
            return accountRepository.UpdatePassword(accountId, password);
        }

        public UserAccount UpdateAccountEmail(long accountId, string email)
        {
            return accountRepository.UpdateEmail(accountId, email);
        }

        public UserAccount UpdateAccountData(long accountId, UserData data)
        {
            return accountRepository.UpdateUserData(accountId, data);
        }
    }
}
