using Piko.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Piko.DTO
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Username not specified ")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Min/Max length is 1/25")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email not specified ")]
        [EmailAddress(ErrorMessage = "Incorrect Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password not specified ")]
        public string? Password { get; set; }
    }

    public class UserDetailDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? EMail { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public List<Contest> Contests { get; set; } = new();
        public List<Contest> ContestsPassed { get; set; } = new();
        public List<Contest> ContestsLiked { get; set; } = new();
    }
}