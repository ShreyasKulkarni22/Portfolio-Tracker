using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Net;

namespace FlightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        [Route("/api/flights")]
        public async Task<IActionResult> AddFlight([FromBody] Flight flight)
        {
            try
            {
                Flight newFlight = await _flightService.AddFlight(flight);
                return Created("/api/flights", newFlight);
            }
            catch (NoFlightScheduledException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("/api/flights/{flightid}")]
        public async Task<IActionResult> UpdateFlight(int flightid,[FromBody] Flight flight)
        {
            try
            {
                var newFlight = await _flightService.UpdateFlight(flightid,flight);
                if (newFlight)
                {
                    return Ok(newFlight);
                }
                else
                {

                    throw new NoFlightScheduledException("Could not process the update request..");
                }
            }
            catch (NoFlightScheduledException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("/api/flights/{flightid}")]
        public async Task<IActionResult> DeleteFlight(int flightid)
        {
            try
            {

                bool deleted = await _flightService.SuspendFlight(flightid);
                if (deleted)
                    return Ok("true");
                else
                    throw new NoFlightScheduledException("No flight with specified id found..");
            }
            catch (NoFlightScheduledException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("/api/flights/{flightid}")]
        public async Task<IActionResult> GetFlightByFlightId(int flightid)
        {
            try
            {
                Flight flight =await _flightService.GetFlightDetailsById(flightid);
                if (flight != null)
                {
                    return Ok(flight);

                }
                else
                {
                    throw new NoFlightScheduledException($"No flight scheduled with Id - {flightid}");
                }

            }
            catch (NoFlightScheduledException ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpGet]
        [Route("/api/flights/bydate/{flightdate}")]
        public async Task<IActionResult> GetFlightByFlightDate(DateTime flightdate)
        {
            try
            {
                var flights = await _flightService.GetFlightDetailsByDate(flightdate);
                if (flights is not null)
                {
                    return Ok(flights);

                }
                else
                {
                    throw new NoFlightScheduledException($"No flights scheduled on specified Date - {flightdate}");
                }

            }
            catch (NoFlightScheduledException ex)
            {
                return NotFound(ex.Message);
            }

        }



        [HttpGet]
        [Route("/api/flights/operational/{flightdate}")]
        public async Task<IActionResult> GetOperationalFlightByFlightDate(DateTime flightdate)
        {
            try
            {
                var flights = await _flightService.GetOperationalFlightDetailsByDate(flightdate);
                if (flights != 0)
                {
                    return Ok(flights);

                }
                else
                {
                    throw new NoFlightScheduledException($"No flights operational on specified Date - {flightdate}");
                }

            }
            catch (NoFlightScheduledException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        [Route("/api/flights")]
        public async Task<IActionResult> GetFlightsBySourceDest(string source,string dest)
        {
            try
            {
                var flights = await _flightService.GetFlightDetails(source,dest);
                if (flights is not null)
                {
                    return Ok(flights);

                }
                else
                {
                    throw new NoFlightScheduledException($"No flights scheduled from {source} to {dest}");
                }

            }
            catch (NoFlightScheduledException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
