using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using Townsend.Domain.Abstract;
using Townsend.Domain.Entities;
using Townsend.Web.Infrastructure.Queries;

namespace Townsend.Web.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext request, Type controllerType)
        {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            var mock = new Mock<ILeagueRepository>();
            mock.Setup(m => m.GetLeagueData).Returns(new List<Angler>
            {
                new Angler
                {
                    Surname = "Lennon",
                    FirstName = "John",
                    Points = 18,
                    TotalWeight = 123.12
                },
                new Angler
                {
                    Surname = "McCartney",
                    FirstName = "Paul",
                    Points = 21,
                    TotalWeight = 145.01
                },
                new Angler
                {
                    Surname = "Star",
                    FirstName = "Ringo",
                    Points = 18,
                    TotalWeight = 104.10
                },
                new Angler
                {
                    Surname = "Harrison",
                    FirstName = "George",
                    Points = 11,
                    TotalWeight = 295.10
                }
            }.AsQueryable());

            //Domain
            _ninjectKernel.Bind<ILeagueRepository>().ToConstant(mock.Object);

            //Web
            _ninjectKernel.Bind<IGetLeagueDataQuery>().To<GetLeagueDataQuery>();
        }
    }
}