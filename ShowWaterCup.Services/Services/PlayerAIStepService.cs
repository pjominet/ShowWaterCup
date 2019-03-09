using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Contracts;
using ShowWaterCup.Services.Repositories;
using ShowWaterCup.Services.Models.Player;
using Entities = ShowWaterCup.Services.Entities;
using AutoMapper;

namespace ShowWaterCup.Services.Services
{
    public class PlayerAIStepService : IPlayerAIStepService
    {
        private readonly PlayerAIStepRepository _playerAIStepRepository;

        public PlayerAIStepService()
        {
            var context = new Entities.ShowWaterCupEntities();
            _playerAIStepRepository = new PlayerAIStepRepository(context);
        }

        public int CreatePlayerAIStep(PlayerAIStep playerAIStep)
        {
            var entity = Mapper.Map<Entities.PlayerAIStep>(playerAIStep);
            _playerAIStepRepository.Add(playerAIStep);
            _playerAIStepRepository.SaveChanges();
            return entity.PlayerAIStepId;
        }

        public PlayerAIStep GetPlayerAIStep(int PlayerAIStepId)
        {
            var playerAIStep = _playerAIStepRepository.GetFirst<Entities.PlayerAIStep>(aiStep => aiStep.PlayerAIStepId == PlayerAIStepId);
            return Mapper.Map<PlayerAIStep>(playerAIStep);
        }

        public void UpdatePlayerAIStep(PlayerAIStep playerAIStep)
        {
            var entity = _playerAIStepRepository.GetFirst<Entities.PlayerAIStep>(aiStep => aiStep.PlayerAIStepId == playerAIStep.PlayerAIStepId);
            Mapper.Map(playerAIStep, entity);
            _playerAIStepRepository.SaveChanges();
        }
    }
}
