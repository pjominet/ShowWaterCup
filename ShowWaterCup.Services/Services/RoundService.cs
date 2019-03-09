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
            var entity = Mapper.Map<Entities.Round>(round);
            _roundRepository.Add(entity);
            _roundRepository.SaveChanges();
            return entity.RoundId;
        }        

        public Round GetRound(int roundId)
        {
            var round = _roundRepository.GetFirst<Entities.Round>(r => r.RoundId == roundId);
            return Mapper.Map<Round>(round);
        }

        public IEnumerable<Round> GetRounds(int tournamentId)
        {
            var rounds = _roundRepository.GetAll<Entities.Round>(r => r.TournamentId == tournamentId);
            return Mapper.Map<IEnumerable<Round>>(rounds);
        }
    }
}
