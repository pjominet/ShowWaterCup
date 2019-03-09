using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Repositories
{
    public class RoundActionRepository : BaseRepository<Entities.ShowWaterCupEntities>
    {
        public RoundActionRepository() : base(new Entities.ShowWaterCupEntities())
        {
        }

        public RoundActionRepository(Entities.ShowWaterCupEntities context) : base(context) { }
    }
}
