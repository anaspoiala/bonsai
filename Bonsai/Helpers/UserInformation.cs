using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Helpers
{
    public class UserInformation
    {
        public int? CurrentUserIdNullable { private get; set; } = null;

        public bool IsLoggedIn => CurrentUserIdNullable.HasValue;

        public int CurrentUserId => CurrentUserIdNullable == null
            ? throw new InvalidOperationException("User is not logged in")
            : CurrentUserIdNullable.Value;
    }
}
