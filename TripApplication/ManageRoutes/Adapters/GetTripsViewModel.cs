namespace TripApplication.ManageRoutes
{
    public class GetTripsViewModel
    {
        public Guid Id { get; set; } 
        public string From { get; set; } 
        public string To { get; set; } 
        public string Value { get; set; }
        public IEnumerable<GetStopOversViewModel> StopOvers { get; set; }
    }

    public class GetStopOversViewModel
    {
        public Guid Id { get; set; }
        public string Stop { get; set; }

    }
}
