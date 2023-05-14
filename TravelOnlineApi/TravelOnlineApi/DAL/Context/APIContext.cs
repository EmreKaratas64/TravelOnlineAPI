using Microsoft.EntityFrameworkCore;
using TravelOnlineApi.DAL.Entities;

namespace TravelOnlineApi.DAL.Context
{
    public class APIContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NKLMS7G\\MSSQLSERVER01;initial catalog=TravelOnlineApiDB;integrated security=true");
        }

        public DbSet<Visitor> Visitors { get; set; } = null!;
    }
}
