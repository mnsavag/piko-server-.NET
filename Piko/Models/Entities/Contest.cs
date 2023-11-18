using Piko.Dto;
using System.ComponentModel.DataAnnotations;


namespace Piko.Models.Entities
{
    public class Contest
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }
        public string PreviewFirst { get; set; } = "";
        public string PreviewSecond { get; set; } = "";

        [Required]
        public List<Option> Options { get; set; } = new();
        public int AmountOptions { get; set; }
        public int CountPassed { get; set; } = 0;
        public bool CanBePublished { get; set; } = false;

        public DateTime CreatedDate { get; set; }

        public User? User { get; set; }
        public int? UserId { get; set; }
        public List<Category> Categories { get; set; } = new();
        public List<User> UsersPassed { get; } = new();
        public List<User> UsersLiked { get; } = new();

        public Contest() { }

        public Contest(string name, string description, List<CreateOptionDto> options, List<Category> categories)
        {
            Name = name;
            Description = description;
            Categories = categories;
            AmountOptions = options.Count;
            CreatedDate = DateTime.UtcNow;

            for (int i = 0; i < options.Count; i++)
            {
                Options.Add(new Option()
                {
                    Id = i + 1,
                    Name = options[i].Name,
                });
            }
        }
    }

    public class Option
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string Image { get; set; } = "";
        public int VictoryCount { get; set; } = 0;
    }
}