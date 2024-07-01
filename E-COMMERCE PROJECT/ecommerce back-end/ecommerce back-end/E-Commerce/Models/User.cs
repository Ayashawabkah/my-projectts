using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
    }
}
