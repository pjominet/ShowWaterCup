using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWaterCup.Services.Models.Blockly
{
    public class FieldBlock : AbstractBlock
    {
        public Field Field { get; set; }

        public FieldBlock(string type, Field field)
        {
            Type = type;
            Field = field;
        }
    }    
}
