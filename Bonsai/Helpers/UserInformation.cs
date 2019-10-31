using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Helpers
{
    public class UserInformation
    {
        public int CurrentUserId { get; set; }

        public UserInformation()
        {
            CurrentUserId = -1;
        }
    }
}
