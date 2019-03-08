using System.Collections.Generic;
using System.Web.Http;
using ShowWaterCup.Services.Models;
using ShowWaterCup.Services.Models.Enums;

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
        public Tournament Get(int id)
        {
            var roundActions = new List<RoundAction>
            {
                new RoundAction
                {
                    PlayerId = 1,
                    ActionType = ActionType.Move,
                    Target = "A2"
                },
                new RoundAction
                {
                    PlayerId = 2,
                    ActionType = ActionType.Move,
                    Target = "I10"
                }
            };
            var tournament = new Tournament
            {
                Rounds = new List<Round>
                {
                    {new Round
                    {
                        RoundActions = roundActions
                    }}
                }
            };
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