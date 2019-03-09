using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Contracts;
using ShowWaterCup.Services.Entities;
using ShowWaterCup.Services.Repositories;

namespace ShowWaterCup.Services.Services
{
    public class RoundActionService : IRoundActionService
    {
        private readonly RoundActionRepository _roundActionRepository;

        public RoundActionService()
        {
            var context = new ShowWaterCupEntities();
            _roundActionRepository = new RoundActionRepository(context);
        }

        public int CreateAction(RoundAction action)
        {
            _roundActionRepository.Add(action);
            _roundActionRepository.SaveChanges();
            return action.ActionId;
        }
        

        public RoundAction GetAction(int actionId)
        {
            return _roundActionRepository.GetFirst<RoundAction>(a => a.ActionId == actionId);
        }

        public IEnumerable<RoundAction> GetActions(int roundId)
        {
            return _roundActionRepository.GetAll<RoundAction>(a => a.RoundId == roundId);
        }
    }
}
