namespace Domain.DTOs.Response
{
    public class AddressSummaryDTO
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }
}