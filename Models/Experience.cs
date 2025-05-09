﻿namespace EugeneCV.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Duration { get; set; }
        public string Technology { get; set; }
        public List<ExperienceDescription>? Descriptions { get; set; }
        public List<Screenshot>? Screenshots { get; set; }
        public int Priority { get; set; }
    }
}
