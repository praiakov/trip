namespace TripDomain.Entities
{
    public class StopOvers
    {
        public Guid Id {  get; set; }
        public string Stop { get; set; }

        public Trip Trip { get; set; }
        public Guid TripId { get; set; }
    }
}
