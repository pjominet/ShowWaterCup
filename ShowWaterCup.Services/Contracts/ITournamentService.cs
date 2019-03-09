using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Entities;

namespace ShowWaterCup.Services.Contracts
{
    public interface ITournamentService
    {
        Tournament GetTournament(int tournamentId);
        IEnumerable<Tournament> GetTournaments();
        int CreateTournament(Tournament tournament);
    }
}
