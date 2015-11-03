using AppServiceOverview.Data;
using AppServiceOverview.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppServiceOverview.Web.Controllers
{
    public class RankController : ApiController
    {

        public IHttpActionResult GetTeamRank(int id)
        {
            var dataContext = new AppServiceDataContext();
            var repository = new Repository(dataContext);

            var team = repository.GetById<Team>(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }
    }
}
