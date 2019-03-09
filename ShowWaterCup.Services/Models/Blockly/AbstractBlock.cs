using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShowWaterCup.Services.Models.Blockly
{

    public abstract class AbstractBlock
    {
        public string Type { get; set; }
        public AbstractBlock NextBlock { get; set; }
    }
}
