using ShowWaterCup.Services.Contracts;
using ShowWaterCup.Services.Repositories;
using ShowWaterCup.Services.Models.Player;
using Entities = ShowWaterCup.Services.Entities;
using AutoMapper;

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
            var entity = Mapper.Map<Entities.PlayerAI>(playerAI);
            _playerAIRepository.Add(playerAI);
            _playerAIRepository.SaveChanges();
            return entity.AiId;
        }

        public PlayerAI GetPlayerAI(int AiId)
        {
            var playerAIStep = _playerAIRepository.GetFirst<Entities.PlayerAI>(ai => ai.AiId == AiId);
            return Mapper.Map<PlayerAI>(playerAIStep);
        }

        public void UpdatePlayerAI(PlayerAI playerAI)
        {
            var entity = _playerAIRepository.GetFirst<Entities.PlayerAI>(ai => ai.AiId == playerAI.AiId);
            Mapper.Map(playerAI, entity);
            _playerAIRepository.SaveChanges();
        }
    }
}
