﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace ShowWaterCup.Services.Models.Blockly
{
    public class Field
    {
        public string FieldType { get; set; }
        public string FieldName { get; set; }
        public string Content { get; set; }
    }
}
