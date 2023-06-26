using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlightDetailsDBContext:DbContext
    {
        public FlightDetailsDBContext() { }
        public FlightDetailsDBContext(DbContextOptions<FlightDetailsDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Flight> flights { get; set; }
    }
}
