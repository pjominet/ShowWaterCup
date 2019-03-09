using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace ShowWaterCup.Services.Models.Blockly
{
    [XmlRoot(ElementName = "xml", Namespace = "http://www.w3.org/1999/xhtml")]
    public class Xml
    {
        [XmlElement(ElementName = "block", Namespace = "http://www.w3.org/1999/xhtml")]
        public List<Block> Block { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
