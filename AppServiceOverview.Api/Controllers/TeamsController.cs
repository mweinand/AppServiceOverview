using AppServiceOverview.Api.Models;
using AppServiceOverview.Data;
using AppServiceOverview.Data.Entities;
using Microsoft.Azure.AppService.ApiApps.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AppServiceOverview.Api.Controllers
{
    public class TeamsController : ApiController
    {
        private readonly IAsyncRepository repository;

        public TeamsController()
        {
            var dataContext = new AppServiceDataContext();
            this.repository = new Repository(dataContext);
        }

        [ResponseType(typeof(Team))]
        public IHttpActionResult Get(int id)
        {
            var team = repository.GetById<Team>(id);

            if (team == null)
            {
                return NotFound();
            }

            var result = new TeamModel
            {
                TeamNumber = id,
                Rank = team.Rank
            };

            return Ok(result);
        }

        #region Logic App Trigger
        //[Route("api/teams/{id}/ranktrigger")]
        //[ResponseType(typeof(Team))]
        //public HttpResponseMessage GetRankUpdatedTrigger(string triggerState, int id)
        //{
        //    var team = repository.GetById<Team>(id);
            
        //    var lastTriggerTimeUtc = String.IsNullOrEmpty(triggerState)
        //        ? DateTime.MinValue
        //        : DateTime.Parse(triggerState).ToUniversalTime();

        //    if (team == null)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NotFound);
        //    }

        //    if (team.LastUpdated > lastTriggerTimeUtc)
        //    {
        //        return this.Request.EventTriggered(team);
        //    }

        //    return this.Request.EventWaitPoll(new TimeSpan(0, 1, 0));
        //}
        #endregion
    }
}
