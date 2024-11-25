namespace TripApplication.ManageRoutes
{
    public class CreateTripWithRoutesViewModel
    {
        public CreateTripWithRoutesViewModel(Guid id) => Id = id;
        
        public Guid Id { get; set; }
    }
}
