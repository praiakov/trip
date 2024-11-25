namespace TripApplication.ManageRoutes
{
    public interface IManageRoutes
    {
        Task<Guid> CreateTripWithRoutes(CreateTripWithRoutesInputModel trip);
        Task<IEnumerable<GetTripsViewModel>> GetRoutes();
        Task<GetTripsViewModel> UpdateRoutes(UpdateTripInputModel updateTripInputModel);
        Task DeleteRoutes(Guid id);
    }
}
