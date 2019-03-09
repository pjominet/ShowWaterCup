using System.Collections.Generic;
using ShowWaterCup.Services.Models.Player;
using ShowWaterCup.Services.Models.Tournament;

namespace ShowWaterCup.Services.Models.Engine
{
    public class TournamentEngine
    {
        private List<PlayerInstance> _players;

        public TournamentEngine()
        {
            _players = new List<PlayerInstance>();
        }

        public void AddPlayer(PlayerInstance player) 
        {
           _players.Add(player);
        }

        public TournamentInstance Start()
        {
            var tournament = new TournamentInstance();
            return tournament;
        }
    }
}