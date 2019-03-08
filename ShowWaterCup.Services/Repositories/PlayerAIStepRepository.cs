using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Repositories
{
    public class PlayerAIStepRepository : BaseRepository<Entities.ShowWaterCupEntities>
    {
        public PlayerAIStepRepository() : base(new Entities.ShowWaterCupEntities())
        {
        }

        public PlayerAIStepRepository(Entities.ShowWaterCupEntities context) : base(context) { }
    }
}
