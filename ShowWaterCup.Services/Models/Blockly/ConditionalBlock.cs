using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Models.Blockly
{
    public class ConditionalBlock : AbstractBlock
    {      
        public Value Value { get; set; }
        public AbstractBlock OnSuccess { get; set; }
        public AbstractBlock Default { get; set; }
    }
}
