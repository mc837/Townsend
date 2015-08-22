using System.Data.Entity;
using Townsend.Domain.Entities;

namespace Townsend.Domain.Concrete
{
    public class LeagueDbContext
    {
        public DbSet<Angler> Anglers { get; set; }
    }
}
