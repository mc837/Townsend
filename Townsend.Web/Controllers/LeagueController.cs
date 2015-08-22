using System.Linq;
using System.Web.Mvc;
using Townsend.Web.Infrastructure.Queries;

namespace Townsend.Web.Controllers
{
    public class LeagueController : Controller
    {
        private readonly IGetLeagueDataQuery _query;

        public LeagueController(IGetLeagueDataQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var anglers = _query.Execute();
            var model = anglers.OrderBy(points => points.Points).ThenByDescending(weight => weight.TotalWeight);
            return View(model);
        }
    }
}
