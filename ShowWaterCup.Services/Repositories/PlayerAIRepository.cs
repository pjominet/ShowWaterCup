using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Repositories
{
    public class PlayerAIRepository : BaseRepository<Entities.ShowWaterCupEntities>
    {
        public PlayerAIRepository() : base(new Entities.ShowWaterCupEntities())
        {
        }

        public PlayerAIRepository(Entities.ShowWaterCupEntities context) : base(context) { }
    }
}
