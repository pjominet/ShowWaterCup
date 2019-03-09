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
            ConditionalBlock previousBlock = ParseConditionalBlock(firstChild);
            AI aI = new AI { FirstBlock = previousBlock };
            XmlNode node = firstChild.NextSibling;
            while (node != null)
            {
                ConditionalBlock newBlock = ParseConditionalBlock(node);
                previousBlock.NextBlock = newBlock;
                previousBlock = newBlock;
                node = firstChild.NextSibling;
            }                
                
            return aI;
        }

        private ConditionalBlock ParseConditionalBlock(XmlNode node)
        {
            ConditionalBlock conditionalBlock = new ConditionalBlock
            {
                Value = new Value()
                {
                    Name = "IF",
                    Block = new LogicalBlock()
                    {
                        Type = "logic_compare",
                        Field = new Field()
                        {
                            Content = "",
                            FieldName = "",
                            FieldType = ""
                        },
                        LeftValue = new Value()
                        {

                        },
                        RightValue = new Value()
                        {

                        }
                    }
                }
            };

            return conditionalBlock;
        }
    }
}
