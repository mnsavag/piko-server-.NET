using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;


namespace Piko.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public List<Contest> Contest { get; set; } = new();
    }
}