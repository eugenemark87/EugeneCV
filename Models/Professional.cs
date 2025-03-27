using System.ComponentModel.DataAnnotations;

namespace EugeneCV.Models
{
    public class Professional
    {
        public int ProfessionalId { get; set; }
        public string CertificateName { get; set; }
        public string Description { get; set; }
    }
}
