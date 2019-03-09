using System.Collections.Generic;

namespace ShowWaterCup.Services.Models.Tournament
{
    public class Round
    {
        public List<RoundAction> RoundActions { get; set; }
        public ArenaMap ArenaMap { get; set; }
   
        
    }
}