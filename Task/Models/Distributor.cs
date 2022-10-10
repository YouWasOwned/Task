using Task.Models.Enums;

namespace Task.Models
{
    public class Distributor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
        public IdentificationInformationType IdentificationInformationType { get; set; }
        public string DocumentSeries { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TermDateOfDocument { get; set; }
        public string PersonalNumber { get; set; }
        public string Agency { get; set; }
        public ContactType ContactType { get; set; }
        public string ContactInformation { get; set; }
        public AddressType AddressType { get; set; }
        public string Address { get; set; }
        public int? RecommenderID { get; set; }
        public int Level { get; set; }
        public int RecommendedDistributorsCount { get; set; }

    }
}