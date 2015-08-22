using System.Collections.Generic;
using System.Linq;
using Townsend.Domain.Abstract;
using Townsend.Domain.Entities;

namespace Townsend.Web.Infrastructure.Queries
{
    public class GetLeagueDataQuery: IGetLeagueDataQuery
    {
        private readonly ILeagueRepository _repository;

        public GetLeagueDataQuery(ILeagueRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Angler> Execute()
        {
            return _repository.GetLeagueData;
        }
    }
}