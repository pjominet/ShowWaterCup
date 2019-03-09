using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Repositories
{
    public class RoundRepository : BaseRepository<Entities.ShowWaterCupEntities>
    {
        public RoundRepository() : base(new Entities.ShowWaterCupEntities())
        {
        }

        public RoundRepository(Entities.ShowWaterCupEntities context) : base(context) { }
    }
}
