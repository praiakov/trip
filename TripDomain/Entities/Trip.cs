namespace TripDomain.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Value { get; set; }
        public IList<StopOvers> StopOvers { get; set; }
    }
}
