using System.ComponentModel.DataAnnotations;


namespace Piko.Dto
{
    public class CreateOptionDto
    {
        [Required(ErrorMessage = "Name not specified ")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Min/Max length is 1/25")]
        public string? Name { get; set; }
    }

    public class OptionGetDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int VictoryCount { get; set; }
        public double WinRate { get; set; }
    }
}