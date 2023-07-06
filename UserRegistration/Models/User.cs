using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
