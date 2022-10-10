using Task.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Task.Requests
{
    public class RegisterDistributorRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }

        [Required]
        public IdentificationInformationType IdentificationInformationType { get; set; }

        [MaxLength(10)]
        public string DocumentSeries { get; set; }

        [MaxLength(10)]
        public string DocumentNumber { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime TermDateOfDocument { get; set; }

        [Required]
        [MaxLength(50)]
        public string PersonalNumber { get; set; }

        [MaxLength(100)]
        public string Agency { get; set; }

        [Required]
        public ContactType ContactType { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactInformation { get; set; }

        public AddressType AddressType { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public int? RecommenderID { get; set; }

    }
}