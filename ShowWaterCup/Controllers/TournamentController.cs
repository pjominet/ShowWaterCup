using System.Collections.Generic;
using System.Web.Http;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Player;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Controllers
{
   
    public class TournamentController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        public TournamentInstance Get(int id)
        {
            var tournament = new TournamentInstance();
            tournament.LaunchTournament();
            return tournament;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}