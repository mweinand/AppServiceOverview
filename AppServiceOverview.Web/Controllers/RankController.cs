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
            return Ok(5);
        }
    }
}
