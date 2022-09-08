namespace Redkik.Classes
{
    public class QuotePayload
    {
        public BookingHolder bookingHolder { get; set; }
        public string commodityDescription { get; set; }
        public string commodityId { get; set; }
        public double insuredValue { get; set; }
        public List<JourneyLeg> journeyLegs { get; set; }
        public string trackingCode { get; set; }
        public string externalReference { get; set; }

        public QuotePayload(DateTimeOffset startTime, DateTimeOffset endTime, string origin, 
            string destination, string transportType, string commodityId, string commodityDescription,
            double insuredValue, string holderType, string email, string? businessName, string? forename,
            string? surname, string? taxId, string addressStreet, string addressLocality,
            string addressState, string addressPostcode, string addressCountry, string? trackingCode, string? externalReference)
        {
            journeyLegs = new List<JourneyLeg>
            {
                new JourneyLeg(startTime, endTime, origin, destination, transportType)
            };
            this.commodityId = commodityId;
            this.commodityDescription = commodityDescription;
            this.insuredValue = insuredValue;
            this.bookingHolder = new BookingHolder(holderType, email, businessName, forename, surname,
                taxId, addressStreet, addressLocality, addressState, addressPostcode, addressCountry);
            this.trackingCode = trackingCode == null ? "" : trackingCode;
            this.externalReference = externalReference == null ? "" : externalReference;
        }
    }
}
