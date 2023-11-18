using Piko.Validators;
using System.ComponentModel.DataAnnotations;

namespace Piko.Dto
{
    public class ContestDto
    {
        public class ContestCreateDto
        {
            [Required(ErrorMessage = "Name not specified ")]
            [StringLength(25, MinimumLength = 1, ErrorMessage = "Min/Max length is 1/25")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Description is not specified ")]
            [StringLength(25, MinimumLength = 1, ErrorMessage = "Min/Max length is 1/250")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Categories not specified ")]
            [CollectionLength(1, 2, ErrorMessage = "Min/Max length 1/2")]
            public List<int> CategoriesIds { get; set; }

            [Required(ErrorMessage = "Options not specified ")]
            [CollectionAvailLengths(new int[]{8, 16, 32, 64}, ErrorMessage = "avalable lengths 8/16/32/64")]
            public List<CreateOptionDto> Options { get; set; }
        }

        public class ContestUploadImagesDto
        {
            [Required(ErrorMessage = "First preview not specified")]
            public IFormFile PreviewFirst { get; set; }            
            
            [Required(ErrorMessage = "Second preview not specified")]
            public IFormFile PreviewSecond { get; set; }

            [Required(ErrorMessage = "Options")]
            [CollectionAvailLengths(new int[] { 8, 16, 32, 64 }, ErrorMessage = "avalable lengths 8/16/32/64")]
            public List<IFormFile> Options { get; set; }
        }
    }
}