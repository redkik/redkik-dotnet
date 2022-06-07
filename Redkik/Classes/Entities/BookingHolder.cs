namespace Redkik.Classes
{
    public class BookingHolder
    {
        public string? type { get; set; }
        public string? email { get; set; }
        public string? businessName { get; set; }
        public string? forename { get; set; }
        public string? surname { get; set; }
        public string? taxId { get; set; }
        public string? addressStreet { get; set; }
        public string? addressLocality { get; set; }
        public string? addressState { get; set; }
        public string? addressPostcode { get; set; }
        public string? addressCountry { get; set; }

        public BookingHolder(string type, string email, string? businessName, string? forename,
            string? surname, string? taxId, string addressStreet, string addressLocality,
            string addressState, string addressPostcode, string addressCountry)
        {
            this.type = type;
            this.email = email;
            this.businessName = businessName;
            this.forename = forename;
            this.surname = surname;
            this.taxId = taxId;
            this.addressStreet = addressStreet;
            this.addressLocality = addressLocality;
            this.addressState = addressState;
            this.addressPostcode = addressPostcode;
            this.addressCountry = addressCountry;
        }
    }
}