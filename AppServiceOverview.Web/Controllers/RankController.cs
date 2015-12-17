using AppServiceOverview.Data;
using AppServiceOverview.Data.Entities;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppServiceOverview.Web.Controllers
{
    public class RankController : ApiController
    {

        public async Task<IHttpActionResult> GetTeamRank(int id)
        {
            Trace.TraceInformation("Getting rank for team {0}", id);

            var dataContext = new AppServiceDataContext();
            var repository = new Repository(dataContext);

            var team = await repository.GetByIdAsync<Team>(id);

            if (team == null)
            {
                Trace.TraceWarning("Team not found in database: {0}", id);
                return NotFound();
            }

            return Ok(team);
        }
    }
}
