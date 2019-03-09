using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace ShowWaterCup.Services.Models.Blockly
{
    [XmlRoot(ElementName = "field", Namespace = "http://www.w3.org/1999/xhtml")]
    public class Field
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
