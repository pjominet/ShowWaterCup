using System.Collections.Generic;
using System.Linq;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Player;

namespace ShowWaterCup.Services.Models.Tournament
{
    public class TournamentInstance
    {
        public const int MAX_ROUNDS = 50; // keep it simple at the beginning
        public List<Round> PlayedRounds { get; set; }
        public List<PlayerInstance> Players { get; set; }

        public TournamentInstance()
        {
            PlayedRounds = new List<Round>();
            // mock players
            Players = new List<PlayerInstance>
            {
                new PlayerInstance(1,"Player1", Character.Char1, 5, new MapPosition(1,1), ArenaMap.ARENA_SIZE),
                new PlayerInstance(2,"Player2", Character.Char2, 5, new MapPosition(20,20), ArenaMap.ARENA_SIZE)
            }; 
        }

        public void LaunchTournament()
        {
            for (var i = 0; i < MAX_ROUNDS; i++)
            {
                var round = new Round
                {
                    ArenaMap = i == 0 ? new ArenaMap() : PlayedRounds.Last().ArenaMap
                };

                if (i % 5 == 0)
                {
                    round.ArenaMap.Flood();
                }

                // actual player turns
                round.RoundActions = new List<RoundAction>();
                foreach (var player in Players)
                {
                    round.RoundActions.AddRange(player.Play());
                }

                PlayedRounds.Add(round);
            }
        }
    }
}