using System;
using System.Collections.Generic;
using System.Text;
using Bonsai.Domain;

namespace Bonsai.Persistence
{
    public interface IAccountRepository
    {
        UserAccount CreateAccount(UserAccount account);
        UserAccount DeleteAccount(long accountId);
        UserAccount GetAccountById(long id);
        UserAccount UpdateEmail(long id, string newEmail);
        UserAccount UpdatePassword(long id, string newPassword);
        UserAccount UpdateUserData(long accountId, UserData newUserData);
    }
}
