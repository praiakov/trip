using TripDomain.Entities;

namespace TripDomain.Interfaces
{
    public interface IRepository
    {
        Task Create(Trip trip);
        Task<Trip> Search(string from, string to);
        Task<IEnumerable<Trip>> Get();
        Task<Trip> Get(Guid id);
        Task Delete(Guid id);
        Task<Trip> Update(Trip trip);
        Task RemoveStopOvers(IEnumerable<StopOvers> stopOvers);
    }
}
