using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace ShowWaterCup.Services.Models.Blockly
{
    [XmlRoot(ElementName = "value", Namespace = "http://www.w3.org/1999/xhtml")]
    public class Value
    {
        [XmlElement(ElementName = "block", Namespace = "http://www.w3.org/1999/xhtml")]
        public Block Block { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
