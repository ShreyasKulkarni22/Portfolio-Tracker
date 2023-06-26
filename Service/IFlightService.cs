using Entities;

namespace Service
{
    public interface IFlightService
    {
        public Task<Flight> AddFlight(Flight flight);
        public Task<bool> SuspendFlight(int id);
        public Task<bool> UpdateFlight(int id, Flight flight);
        public Task<Flight> GetFlightDetailsById(int id);
        public Task<IEnumerable<Flight>> GetFlightDetails(string source, string dest);

        public Task<IEnumerable<Flight>> GetFlightDetailsByDate(DateTime date);
        public Task<int> GetOperationalFlightDetailsByDate(DateTime date);
    }
}