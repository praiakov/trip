using Microsoft.EntityFrameworkCore;
using TripDomain.Entities;
using TripDomain.Interfaces;

namespace TripInfra
{
    public class Repository : IRepository
    {
        private readonly TripContext _tripContext;

        public Repository(TripContext tripContext) => _tripContext = tripContext;

        public Task Create(Trip trip)
        {
            _tripContext.Trips.Add(trip);
            _tripContext.StopOvers.AddRange(trip.StopOvers);
            _tripContext.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Trip>> Get()
        {
            var trip = _tripContext.Trips.AsNoTracking().Include(x => x.StopOvers)
                                         .ToList();

            return await Task.FromResult(trip);
        }

        public async Task<Trip> Get(Guid id)
        {
            var trip = _tripContext.Trips.AsNoTracking().Include(x => x.StopOvers).Where(x=> x.Id == id).FirstOrDefault();

            return await Task.FromResult(trip);
        }

        public async Task<Trip> Search(string from, string to)
        {
            var trip = _tripContext.Trips.Where(x => x.From.Equals(from, StringComparison.OrdinalIgnoreCase) && x.To.Equals(to, StringComparison.OrdinalIgnoreCase))
                                          .Include(x => x.StopOvers)
                                          .OrderBy(x => x.Value)
                                          .First();

            return await Task.FromResult(trip);
        }

        public async Task<Trip> Update(Trip trip)
        {
            _tripContext.Update(trip);
            _tripContext.SaveChanges();

            return await Task.FromResult(trip);
        }

        public async Task RemoveStopOvers(IEnumerable<StopOvers> stopOvers)
        {
            _tripContext.StopOvers.RemoveRange(stopOvers);
            _tripContext.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var trip = _tripContext.Trips.Find(id);
            _tripContext.Trips.Remove(trip);
            _tripContext.SaveChanges();

            await Task.FromResult(trip);

        }
    }
}
