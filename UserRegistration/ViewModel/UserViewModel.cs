using System.ComponentModel.DataAnnotations;

namespace UserRegistration.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
