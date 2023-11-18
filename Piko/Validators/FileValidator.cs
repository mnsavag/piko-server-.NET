namespace Piko.Validators
{
    public class FileValidator
    {
        public static bool isValidImage(IFormFile file)
        {
            var availableFormats = new string[] { ".jpg", ".jpeg", ".png" };
            return availableFormats.Contains(Path.GetExtension(file.FileName));
        }
    }
}
