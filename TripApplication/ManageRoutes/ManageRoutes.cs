using TripDomain.Entities;
using TripDomain.Interfaces;

namespace TripApplication.ManageRoutes
{
    public class ManageRoutes : IManageRoutes
    {
        private readonly IRepository _repository;

        public ManageRoutes(IRepository repository) => _repository = repository;

        public Task DeleteRoutes(Guid id) => _repository.Delete(id);

        public async Task<IEnumerable<GetTripsViewModel>> GetRoutes()
        {
            var trips = await _repository.Get();

            return trips.Select(x => new GetTripsViewModel
            {
                From = x.From,
                To = x.To,
                Id = x.Id,
                Value = x.Value.ToString(),
                StopOvers = x.StopOvers.Select(s => new GetStopOversViewModel { Id = s.Id, Stop = s.Stop }).ToList()
            });
        }

        public async Task<GetTripsViewModel> UpdateRoutes(UpdateTripInputModel updateTripInputModel)
        {
            var trip = await _repository.Get(updateTripInputModel.Id);

            trip.From = updateTripInputModel.From;
            trip.To = updateTripInputModel.To;
            trip.Value = updateTripInputModel.Value;

            await _repository.RemoveStopOvers(trip.StopOvers);

            trip.StopOvers = updateTripInputModel.StopOvers.Select(x => new StopOvers { Stop = x.Stop }).ToList();

            var routes = await _repository.Update(trip);

            return new GetTripsViewModel
            {
                Id = trip.Id,
                From = trip.From,
                To = trip.To,
                Value = trip.Value.ToString(),
                StopOvers = routes.StopOvers.Select(s => new GetStopOversViewModel { Id = s.Id, Stop = s.Stop}).ToList()
            };
        }

        async Task<Guid> IManageRoutes.CreateTripWithRoutes(CreateTripWithRoutesInputModel tripWithRoutes)
        {   
            var stopOvers = tripWithRoutes.StopOvers.Select(x => new StopOvers { Stop = x }).ToList();
            var trip = new Trip
            {
                StopOvers = stopOvers,
                From = tripWithRoutes.From,
                To = tripWithRoutes.To,
                Value = tripWithRoutes.Price,
            };

            await _repository.Create(trip);

            return trip.Id;
        }
    }
}
