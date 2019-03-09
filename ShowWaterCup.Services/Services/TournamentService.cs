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
    public class TournamentService : ITournamentService
    {
        private readonly TournamentRepository _tournamentRepository;

        public TournamentService()
        {
            var context = new Entities.ShowWaterCupEntities();
            _tournamentRepository = new TournamentRepository(context);
        }

        public int CreateTournament(Tournament tournament)
        {
            _tournamentRepository.Add(tournament);
            _tournamentRepository.SaveChanges();
            return tournament.TournamentId;
        }

        public Tournament GetTournament(int tournamentId)
        {
            return _tournamentRepository.GetFirst<Tournament>(t => t.TournamentId == tournamentId);
        }

        public IEnumerable<Tournament> GetTournaments()
        {
            return _tournamentRepository.GetAll<Tournament>();
        }
    }
}
