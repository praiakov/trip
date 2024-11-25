namespace TripApplication.ManageRoutes
{
    public class UpdateTripInputModel
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Value { get; set; }
        public IEnumerable<GetStopOversViewModel> StopOvers { get; set; }
    }
}
