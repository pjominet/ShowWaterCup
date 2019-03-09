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
    public class RoundService : IRoundService
    {
        private readonly RoundRepository _roundRepository;

        public RoundService()
        {
            var context = new Entities.ShowWaterCupEntities();
            _roundRepository = new RoundRepository(context);
        }

        public int CreateRound(Round round)
        {
            _roundRepository.Add(round);
            _roundRepository.SaveChanges();
            return round.RoundId;
        }
        

        public Round GetRound(int roundId)
        {
            return _roundRepository.GetFirst<Round>(r => r.RoundId == roundId);
        }

        public IEnumerable<Round> GetRounds(int tournamentId)
        {
            return _roundRepository.GetAll<Round>(r => r.TournamentId == tournamentId);
        }
    }
}
