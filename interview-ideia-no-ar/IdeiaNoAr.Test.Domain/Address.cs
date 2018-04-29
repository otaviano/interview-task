namespace IdeiaNoAr.Test.Domain
{
    public class Address
    {
        public int Id { get; set; }

        public string AddressDesc { get; set; }

        public string Subpremise { get; set; }

        public string StreetNumber { get; set; }

        public string Route { get; set; }

        public string Sublocality { get; set; }

        public string Locality { get; set; }

        public string AdminAreaLevel1 { get; set; }

        public string AdminAreaLevel2 { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string FormattedAddress { get; set; }
    }
}