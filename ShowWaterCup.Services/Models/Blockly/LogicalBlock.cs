using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Models.Blockly
{
    public class LogicalBlock : AbstractBlock
    {
        public Field Field { get; set; }
        public Value LeftValue { get; set; }
        public Value RightValue { get; set; }
    }
}
