using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShowWaterCup.Services.Models.Blockly
{
    [XmlRoot(ElementName = "block", Namespace = "http://www.w3.org/1999/xhtml")]
    public class Block
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "statement", Namespace = "http://www.w3.org/1999/xhtml")]
        public Statement Statement { get; set; }
        [XmlElement(ElementName = "next", Namespace = "http://www.w3.org/1999/xhtml")]
        public Next Next { get; set; }
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }
    }
}
