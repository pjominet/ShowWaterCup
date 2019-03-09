using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Contracts;
using ShowWaterCup.Services.Models.Tournament;
using Entities = ShowWaterCup.Services.Entities;
using ShowWaterCup.Services.Repositories;
using AutoMapper;

namespace ShowWaterCup.Services.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly TournamentRepository _tournamentRepository;

        public TournamentService()
        {
            var context = new Entities.ShowWaterCupEntities();
            _tournamentRepository = new TournamentRepository(context);
        }

        public int CreateTournament(TournamentInstance tournament)
        {
            var entity = Mapper.Map<Entities.Tournament>(tournament);
            _tournamentRepository.Add(entity);
            _tournamentRepository.SaveChanges();
            return entity.TournamentId;
        }

        public TournamentInstance GetTournament(int tournamentId)
        {
            var tournament =  _tournamentRepository.GetFirst<Entities.Tournament>(t => t.TournamentId == tournamentId);
            return Mapper.Map<TournamentInstance>(tournament);
        }

        public IEnumerable<TournamentInstance> GetTournaments()
        {
            var tournaments = _tournamentRepository.GetAll<Entities.Tournament>();
            return Mapper.Map<IEnumerable<TournamentInstance>>(tournaments);
        }
    }
}
