namespace Piko.Models
{
    public class ContestFiles
    {
        public required string RootSysPath { get; set; }
        public required string ContestDir { get; set; }
        public required string PreviewDir { get; set; }
        public required string OptionsDir { get; set; }
    }
}