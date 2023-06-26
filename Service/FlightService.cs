using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FlightService : IFlightService
    {
        IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Flight> AddFlight(Flight flight)
        {
           var fare=await _flightRepository.AddFlight(flight);
            return fare;
        }

        public async Task<IEnumerable<Flight>> GetFlightDetails(string source, string dest)
        {
            
            var flights = await _flightRepository.GetFlightDetails(source, dest);
            if (flights is null)
            {
                throw new NoFlightScheduledException($"No Flights scheduled from {source} to {dest}");
            }
            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightDetailsByDate(DateTime date)
        {
            var flights =await  _flightRepository.GetFlightDetailsByDate(date);
            if (flights is null)
            {
                throw new NoFlightScheduledException($"No Flights scheduled for specified date - {date}");
            }
            return flights;
        }

        public async Task<int> GetOperationalFlightDetailsByDate(DateTime date)
        {
            var flights = await _flightRepository.GetOperationalFlightDetailsByDate(date);
            if (flights ==0)
            {
                throw new NoFlightScheduledException($"No Flights operational for specified date - {date}");
            }
            return flights;
        }

        public async Task<Flight> GetFlightDetailsById(int id)
        {
            var flight=await _flightRepository.GetFlightDetailsById(id);
            if (flight == null)
            {
                throw new NoFlightScheduledException($"No flight with specified id - {id}");
            }
            return flight;
        }

        public async Task<bool> SuspendFlight(int id)
        {
            var flight =await _flightRepository.GetFlightDetailsById(id);
            if (flight==null)
            {
                return false;
            }
            else
            {
                await _flightRepository.SuspendFlight(id);
                return true;
            }
        }

        public async Task<bool> UpdateFlight(int id, Flight flight)
        {
            var fare = await _flightRepository.GetFlightDetailsById(id);
            if (fare == null)
            {
                throw new NoFlightScheduledException("No such flight was scheduled");
            }
            else
            {
                await _flightRepository.UpdateFlight(id,flight);
                return true;
            }
        }
    }
}
