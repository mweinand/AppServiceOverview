using AppServiceOverview.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceOverview.Data
{
    public class AppServiceDataContext : BaseDbContext
    {
        public AppServiceDataContext(string connectionString)
            : base(connectionString)
        {            
        }

        public AppServiceDataContext()
            : this("TestConnectionString")
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
