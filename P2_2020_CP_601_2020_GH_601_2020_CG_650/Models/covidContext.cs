using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using P2_2020_CP_601_2020_GH_601_2020_CG_650.Models;
namespace P2_2020_CP_601_2020_GH_601_2020_CG_650.Models
{
    public class covidContext : DbContext
    {
        public covidContext(DbContextOptions<covidContext> options) : base(options)
        {
        }

        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<genero> genero { get; set; }
        public DbSet<casos> casos { get; set; }


    }
}
