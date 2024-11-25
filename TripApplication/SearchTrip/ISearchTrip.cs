namespace TripApplication.SearchTrip
{
    public interface ISearchTrip
    {
        Task<SearchTripViewModel> GetRoute(SearchTripInputModel trip);
    }
}
