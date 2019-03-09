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
    class XMLReader
    {

        public AI ParseXmlRepresentation(String xmlPayload)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlPayload);
           
            XmlNode firstChild = document.FirstChild;
            ConditionalBlock previousBlock = Parse(firstChild);
            AI aI = new AI { FirstBlock = previousBlock };
            XmlNode node = firstChild.NextSibling;
            while (node != null)
            {
                ConditionalBlock newBlock = Parse(node);
                previousBlock.NextBlock = newBlock;
                previousBlock = newBlock;
                node = firstChild.NextSibling;
            }
                
                
            return null;
        }

        private ConditionalBlock Parse(XmlNode node)
        {
            ConditionalBlock conditionalBlock = new ConditionalBlock();
            conditionalBlock.NextBlock = new ConditionalBlock();

            return conditionalBlock;
        }
    }
}
