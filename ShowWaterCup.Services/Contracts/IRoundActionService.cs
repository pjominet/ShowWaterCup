using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowWaterCup.Services.Entities;

namespace ShowWaterCup.Services.Contracts
{
    public interface IRoundActionService
    {
        RoundAction GetAction(int actionId);
        IEnumerable<RoundAction> GetActions(int roundId);
        int CreateAction(RoundAction action);
    }
}
