using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Models.Tournament;
using Entities = ShowWaterCup.Services.Entities;

namespace ShowWaterCup.Services.Contracts
{
    public interface IRoundService
    {
        Round GetRound(int roundId);
        IEnumerable<Round> GetRounds(int tournamentId);
        int CreateRound(Round round);
    }
}
