using Bonsai.Domain;

namespace Bonsai.Persistence
{
    public interface IAccountRepository
    {
        UserAccount CreateAccount(UserAccount account);
        UserAccount DeleteAccount(long accountId);
        UserAccount GetAccountById(long id);
        UserAccount GetAccountByUsername(string username);
        bool CheckAccountPassword(long id, string password);
        UserAccount UpdateUserData(long accountId, UserData newUserData);
    }
}
