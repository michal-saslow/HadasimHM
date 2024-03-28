using HMOBackOffice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HMOBackOffice.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Member> members { get; set; }
        public DbSet<VaccinationForMember> VaccinationForMembers { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<City> Citys { get; set; }
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cs = _configuration["ConnectionString"];
            optionsBuilder.UseSqlServer(cs);
        }
    }
}
