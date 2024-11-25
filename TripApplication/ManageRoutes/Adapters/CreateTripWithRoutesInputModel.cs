namespace TripApplication.ManageRoutes
{
    public class CreateTripWithRoutesInputModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }
        public IList<string> StopOvers { get; set; }

    }
}
