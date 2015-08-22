using System.Linq;
using Townsend.Domain.Entities;

namespace Townsend.Domain.Abstract
{
    public interface ILeagueRepository
    {
        IQueryable<Angler> GetLeagueData { get; }
        //bool PersistQrMapping(QrEhlMappingModel persistQrModel);
    }
}