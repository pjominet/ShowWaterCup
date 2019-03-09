using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Contracts;
using ShowWaterCup.Services.Repositories;
using ShowWaterCup.Services.Models.Tournament;
using Entities = ShowWaterCup.Services.Entities;
using AutoMapper;

namespace ShowWaterCup.Services.Services
{
    public class RoundActionService : IRoundActionService
    {
        private readonly RoundActionRepository _roundActionRepository;

        public RoundActionService()
        {
            var context = new Entities.ShowWaterCupEntities();
            _roundActionRepository = new RoundActionRepository(context);
        }

        public int CreateAction(RoundAction action)
        {
            var entity = Mapper.Map<Entities.RoundAction>(action);
            _roundActionRepository.Add(action);
            _roundActionRepository.SaveChanges();
            return entity.ActionId;
        }
        

        public RoundAction GetAction(int actionId)
        {
            var round = _roundActionRepository.GetFirst<Entities.RoundAction>(a => a.ActionId == actionId);
            return Mapper.Map<RoundAction>(round);
        }

        public IEnumerable<RoundAction> GetActions(int roundId)
        {
            var rounds = _roundActionRepository.GetAll<Entities.RoundAction>(a => a.RoundId == roundId);
            return Mapper.Map<IEnumerable<RoundAction>>(rounds);
        }
    }
}
