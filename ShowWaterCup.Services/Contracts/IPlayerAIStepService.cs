using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Models.Player;
using Entities = ShowWaterCup.Services.Entities;

namespace ShowWaterCup.Services.Contracts
{
    public interface IPlayerAIStepService
    {
        PlayerAIStep GetPlayerAIStep(int PlayerAIStepId);
        int CreatePlayerAIStep(PlayerAIStep playerAIStep);
        void UpdatePlayerAIStep(PlayerAIStep playerAIStep);
    }
}
