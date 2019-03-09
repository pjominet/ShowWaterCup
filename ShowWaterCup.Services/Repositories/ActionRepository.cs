using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Repositories
{
    public class ActionRepository : BaseRepository<Entities.ShowWaterCupEntities>
    {
        public ActionRepository() : base(new Entities.ShowWaterCupEntities())
        {
        }

        public ActionRepository(Entities.ShowWaterCupEntities context) : base(context) { }
    }
}
