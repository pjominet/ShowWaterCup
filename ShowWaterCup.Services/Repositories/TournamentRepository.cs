using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Repositories
{
    public class TournamentRepository : BaseRepository<Entities.ShowWaterCupEntities>
    {
        public TournamentRepository() : base(new Entities.ShowWaterCupEntities())
        {
        }

        public TournamentRepository(Entities.ShowWaterCupEntities context) : base(context) { }
    }
}
