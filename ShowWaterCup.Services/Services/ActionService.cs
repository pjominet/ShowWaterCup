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
    public class ActionService : IActionService
    {
        private readonly ActionRepository _actionRepository;

        public ActionService()
        {
            var context = new Entities.ShowWaterCupEntities();
            _actionRepository = new ActionRepository(context);
        }

        public int CreateAction(Entities.Action action)
        {
            _actionRepository.Add(action);
            _actionRepository.SaveChanges();
            return action.ActionId;
        }
        

        public Entities.Action GetAction(int actionId)
        {
            return _actionRepository.GetFirst<Entities.Action>(a => a.ActionId == actionId);
        }

        public IEnumerable<Entities.Action> GetActions(int roundId)
        {
            return _actionRepository.GetAll<Entities.Action>(a => a.RoundId == roundId);
        }
    }
}
