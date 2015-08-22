using System.Collections.Generic;
using System.Linq;
using Townsend.Domain.Entities;

namespace Townsend.Web.Infrastructure.Queries
{
    public interface IGetLeagueDataQuery
    {
        IQueryable<Angler> Execute();        
    }
}