using System.ComponentModel.DataAnnotations;


namespace Piko.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string? Username { get; set; }

        [Required]
        public string? EMail { get; set; }

        [Required]
        public string? Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<Contest> Contests { get; set; } = new();
        public List<Contest> ContestsPassed { get; } = new();
        public List<Contest> ContestsLiked { get; } = new();
    }
}