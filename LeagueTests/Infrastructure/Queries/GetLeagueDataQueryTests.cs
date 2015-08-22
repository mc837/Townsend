using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Townsend.Domain.Abstract;
using Townsend.Domain.Entities;
using Townsend.Web.Infrastructure.Queries;

namespace LeagueTests.Infrastructure.Queries
{
    public class GetLeagueDataQueryTests
    {
        private ILeagueRepository _repository;
        private GetLeagueDataQuery _query;

        [SetUp]
        public void Setup()
        {
            _repository = MockRepository.GenerateMock<ILeagueRepository>();
            _query = new GetLeagueDataQuery(_repository);
        }

        [Test]
        public void Should_CallIntoTheLeagueRepositoryAndGetLeagueData_When_CallingExecute()
        {
            _repository
                .Stub(r => r.GetLeagueData)
                .Return(new List<Angler>().AsQueryable());

            _query.Execute();

            _repository.AssertWasCalled(r => r.GetLeagueData);
        }

    }
}

