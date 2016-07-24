using System.Data.Common;
using System.Data.Entity;
using CommuneCalculator.DB.DbUtils;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.DB
{
    public class ComCalcContext : DbContext
    {
        public ComCalcContext() : base(DbConnectionUtil.CreateConnection(), true)
        {
        }

        public ComCalcContext(DbConnection connection) : base(connection, true)
        {
        }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Roommate> Roommates { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<AbsenceTime> AbsenceTimes { get; set; }
    }
}