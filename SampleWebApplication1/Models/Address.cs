namespace SampleWebApplication1.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? street { get; set; }
        public DateTime PostalCode { get; set; }
    }

    public class AddressController
    {
        public int Id { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? street { get; set; }
    }
}
