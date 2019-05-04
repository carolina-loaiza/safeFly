namespace Entities_POJO
{
    public class AirlineXAirport : BaseEntity
    {
        public int Id { get; set; }
        public string AirlineId { get; set; }
        public string AirportId { get; set; }
        public decimal InscriptionFee { get; set; }
        public string Status { get; set; }
    }
}