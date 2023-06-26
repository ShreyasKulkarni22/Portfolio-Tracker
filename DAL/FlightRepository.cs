using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlightRepository : IFlightRepository
    {
        FlightDetailsDBContext _dbContext;
        public FlightRepository(FlightDetailsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Flight> AddFlight(Flight flight)
        {
            var nwflight=await _dbContext.flights.AddAsync(flight);
            await _dbContext.SaveChangesAsync();
            return nwflight.Entity;
        }

        public async Task<IEnumerable<Flight>> GetFlightDetails(string source, string dest)
        {
            var allflights = await _dbContext.flights.ToListAsync();
            var flights= await _dbContext.flights.Where(f=>f.Flightsource==source).Where(f=>f.Flightdestination==dest).ToListAsync();
            return flights;
        }

        public async Task<Flight> GetFlightDetailsById(int id)
        {
            var flight = await _dbContext.flights.FindAsync(id);
            if (flight != null)
            {
                return flight;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Flight>> GetFlightDetailsByDate(DateTime date)
        {
            var allflights = await _dbContext.flights.ToListAsync();
            var flights = await _dbContext.flights.Where(f => f.FlightDateTime == date).ToListAsync();
            return flights;
        }

        public async Task<bool> SuspendFlight(int id)
        {
            var flight =await  _dbContext.flights.FindAsync(id);
            if(flight!=null)
            {
                _dbContext.flights.Remove(flight);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateFlight(int id,Flight flight)
        {
            var upd =await  _dbContext.flights.FindAsync(id);

            if (upd != null)
            {
                //_dbContext.flights.Update(flight);
                //_dbContext.Entry(flight).State = EntityState.Modified;

                upd.Flightsource = flight.Flightsource;
                upd.Flightdestination=flight.Flightdestination;
                upd.FlightDateTime= flight.FlightDateTime;
                upd.StatusIsOperational = flight.StatusIsOperational;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            

        }

        public async Task<int> GetOperationalFlightDetailsByDate(DateTime date)
        {
            var allflights = await _dbContext.flights.ToListAsync();
            var flights = await _dbContext.flights.Where(f => f.FlightDateTime == date).Where(f=>f.StatusIsOperational==true).ToListAsync();
            return flights.Count();
        }
    }
}
