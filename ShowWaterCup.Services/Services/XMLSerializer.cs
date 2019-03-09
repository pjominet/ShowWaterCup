using ShowWaterCup.Services.Models.Blockly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ShowWaterCup.Services.Services
{
    class XMLSerializer
    {

        public Object Serialize(String xmlPayload)
        {                    
            XmlSerializer serializer = new XmlSerializer(typeof(Xml));
            using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xmlPayload)))
            {
               return (Xml) serializer.Deserialize(reader);
            }
        }
    }
}
