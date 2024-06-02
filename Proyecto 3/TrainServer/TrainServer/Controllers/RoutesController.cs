using Microsoft.AspNetCore.Mvc;
using TrainServer.Entities;

namespace TrainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TrainRoute>? GetAllRoutes()
        {
            return RoutesDB.routes;
        }

        [HttpPost]
        public IActionResult CreateRoute([FromBody] TrainRoute route)
        {
            RoutesDB.routes.Add(route);
            return CreatedAtAction("CreateRoute", null);
        }
    }
}
