using System.Linq;
using Townsend.Domain.Abstract;
using Townsend.Domain.Entities;

namespace Townsend.Domain.Concrete
{
    public class LeagueRepository : ILeagueRepository
    {
        private LeagueDbContext _context = new LeagueDbContext();

        public IQueryable<Angler> GetLeagueData
        {
            get { return _context.Anglers; }
        }

    }
}