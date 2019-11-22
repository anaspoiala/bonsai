using Bonsai.Exceptions;

namespace Bonsai.Helpers
{
    public class UserInformation
    {
        public int? CurrentUserIdNullable { private get; set; } = null;

        public bool IsLoggedIn => CurrentUserIdNullable.HasValue;

        public int CurrentUserId => CurrentUserIdNullable == null
            ? throw new AuthenticationException("User is not logged in")
            : CurrentUserIdNullable.Value;
    }
}
