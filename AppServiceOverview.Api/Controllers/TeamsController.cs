using AppServiceOverview.Api.Models;
using System;
using System.Web.Http;

namespace AppServiceOverview.Api.Controllers
{
    public class TeamsController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var random = new Random();
            var result = new TeamModel
            {
                TeamNumber = id,
                Rank = random.Next(1, 40)
            };
            return Ok(result);
        }
    }
}
