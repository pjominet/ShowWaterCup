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
    public class PlayerAIService : IPlayerAIService
    {
        private readonly PlayerAIRepository _playerAIRepository;

        public PlayerAIService()
        {
            var context = new Entities.ShowWaterCupEntities();
            _playerAIRepository = new PlayerAIRepository(context);
        }

        public int CreatePlayerAI(PlayerAI playerAI)
        {
            _playerAIRepository.Add(playerAI);
            _playerAIRepository.SaveChanges();
            return playerAI.AiId;
        }

        public PlayerAI GetPlayerAI(int AiId)
        {
            return _playerAIRepository.GetFirst<PlayerAI>(ai => ai.AiId == AiId);
        }

        public void UpdatePlayerAI(PlayerAI playerAI)
        {
            var entity = _playerAIRepository.GetFirst<PlayerAI>(ai => ai.AiId == playerAI.AiId);
            entity = playerAI;
            _playerAIRepository.SaveChanges();
        }
    }
}
