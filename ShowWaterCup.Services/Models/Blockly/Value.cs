﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace ShowWaterCup.Services.Models.Blockly
{
    public class Value
    {
        public AbstractBlock Block { get; set; }
        public String Name { get; set; }
    }
}
