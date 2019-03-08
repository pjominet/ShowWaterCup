using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Entities;

namespace ShowWaterCup.Services.Contracts
{
    public interface IPlayerAIService
    {
        PlayerAI GetPlayerAI(int AiId);
        int CreatePlayerAI(PlayerAI playerAI);
        void UpdatePlayerAI(PlayerAI playerAI);
    }
}
