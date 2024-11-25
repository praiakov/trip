using TripDomain.Interfaces;

namespace TripApplication.SearchTrip
{
    public class SearchTrip : ISearchTrip
    {
        private readonly IRepository _repository;

        public SearchTrip(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<SearchTripViewModel> GetRoute(SearchTripInputModel trip)
        {
            var tripsByFromAndTo = await _repository.Search(trip.From, trip.To);

            var stops = string.Join(" - ", tripsByFromAndTo.StopOvers.Select(item => item.Stop));

            return new SearchTripViewModel { Route = $"{tripsByFromAndTo.From} - {stops} {tripsByFromAndTo.To} ao custo de $ {tripsByFromAndTo.Value}" };
        }
    }
}
