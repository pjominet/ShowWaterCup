using System.Collections.Generic;
using System.Linq;
using ShowWaterCup.Services.Models.Enums;
using ShowWaterCup.Services.Models.Player;

namespace ShowWaterCup.Services.Models.Tournament
{
    public class TournamentInstance
    {
        public const int MAX_ROUNDS = 100;
        public List<Round> Rounds { get; set; }

        public TournamentInstance()
        {
            Rounds = new List<Round>();
        }

        public void LaunchTournament()
        {
            for (var i = 0; i < MAX_ROUNDS; i++)
            {
                var round = new Round
                {
                    ArenaMap = i == 0 ? new ArenaMap() : Rounds.Last().ArenaMap
                };

                if (i % 5 == 0)
                {
                    round.ArenaMap.Flood();
                }

                round.RoundActions = new List<RoundAction>();

                round.RoundActions.Add(new RoundAction
                {
                    PlayerId = 1,
                    ActionType = ActionType.Move,
                    Target = new MapPosition(1, 1)
                });
                round.RoundActions.Add(new RoundAction
                {
                    PlayerId = 2,
                    ActionType = ActionType.Move,
                    Target = new MapPosition(10, 10)
                });

                Rounds.Add(round);
            }
        }
    }
}