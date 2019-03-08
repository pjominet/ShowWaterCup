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
    public class PlayerAIStepService : IPlayerAIStepService
    {
        private readonly PlayerAIStepRepository _playerAIStepRepository;

        public PlayerAIStepService()
        {
            var context = new ShowWaterCupEntities();
            _playerAIStepRepository = new PlayerAIStepRepository(context);
        }

        public int CreatePlayerAIStep(PlayerAIStep playerAIStep)
        {
            _playerAIStepRepository.Add(playerAIStep);
            _playerAIStepRepository.SaveChanges();
            return playerAIStep.PlayerAIStepId;
        }

        public PlayerAIStep GetPlayerAIStep(int PlayerAIStepId)
        {
            return _playerAIStepRepository.GetFirst<PlayerAIStep>(aiStep => aiStep.PlayerAIStepId == PlayerAIStepId);
        }

        public void UpdatePlayerAIStep(PlayerAIStep playerAIStep)
        {
            var entity = _playerAIStepRepository.GetFirst<PlayerAIStep>(aiStep => aiStep.PlayerAIStepId == playerAIStep.PlayerAIStepId);
            entity = playerAIStep;
            _playerAIStepRepository.SaveChanges();
        }
    }
}
