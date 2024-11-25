using Microsoft.AspNetCore.Mvc;
using TripApplication.ManageRoutes;
using TripApplication.SearchTrip;

namespace TripApi.Controllers
{
    [ApiController]
    public class TripController : ControllerBase
    {

        private readonly IManageRoutes _manageRoutes;
        private readonly ISearchTrip _trip;

        public TripController(IManageRoutes manageRoutes, ISearchTrip trip)
            => (_manageRoutes, _trip) = (manageRoutes, trip);
        
        [HttpPost("trip")]
        public async Task<IActionResult> CreateTripWithRoutes([FromBody] CreateTripWithRoutesInputModel trip)
        {
            var id = await _manageRoutes.CreateTripWithRoutes(trip);

            return Ok(new CreateTripWithRoutesViewModel(id));
        }

        [HttpGet("search-trip")]
        public async Task<SearchTripViewModel> GetTripWithRoute([FromQuery] string from, string to)
        {
            var trip = new SearchTripInputModel { From = from, To = to };

            return await _trip.GetRoute(trip);
        }

        [HttpGet("trips")]
        public async Task<IEnumerable<GetTripsViewModel>> GetTrips() => await _manageRoutes.GetRoutes();

        [HttpPut("trip")]
        public async Task<GetTripsViewModel> UpdateTrip([FromBody] UpdateTripInputModel updateTripInputModel)
        {
            var result = await _manageRoutes.UpdateRoutes(updateTripInputModel);

            return result;
        }

        [HttpDelete("trip/{id}")]
        public async Task DeleteTrip(Guid id)  =>  await _manageRoutes.DeleteRoutes(id);
        
    }
}
