using System.ComponentModel.DataAnnotations;

namespace Bonsai.Persistence.Model.Accounts
{
    public class UserAccount
    {
        [Key] public long Id { get; set; }
        [Required] public string Username { get; set; }
        [Required] public byte[] PasswordHash { get; set; }
        [Required] public byte[] PasswordSalt { get; set; }
        [Required] public string Email { get; set; }
        public UserData UserData { get; set; }
    }
}
