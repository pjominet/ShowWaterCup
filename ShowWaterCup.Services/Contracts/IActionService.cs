using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Entities;

namespace ShowWaterCup.Services.Contracts
{
    public interface IActionService
    {
        Entities.Action GetAction(int actionId);
        IEnumerable<Entities.Action> GetActions(int roundId);
        int CreateAction(Entities.Action action);
    }
}
