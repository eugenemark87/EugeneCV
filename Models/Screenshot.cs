namespace EugeneCV.Models
{
    public class Screenshot
    {

        public int ScreenshotId { get; set; }

        public int ExperienceId { get; set; }

        public string ImageLink { get; set; }

        public string Caption { get; set; }

        public Experience Exp { get; set; }
    }
}
