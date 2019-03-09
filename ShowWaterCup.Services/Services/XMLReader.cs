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
            AbstractBlock previousBlock = ParseNode(firstChild);
            AI aI = new AI { FirstBlock = previousBlock };
            XmlNode node = firstChild.NextSibling;
            while (node != null)
            {
                AbstractBlock newBlock = ParseNode(node);
                previousBlock.NextBlock = newBlock;
                previousBlock = newBlock;
                node = firstChild.NextSibling;
            }                
                
            return aI;
        }

        private AbstractBlock ParseNode(XmlNode node)
        {
            String nodeType = ((XmlAttribute)node.Attributes.GetNamedItem("type")).Value;
            XmlAttribute a;

            switch (nodeType)
            {
                case "move_forward":
                    return new ActionBlock("move_forward");
                case "move_backward":
                    return new ActionBlock("move_backward");
                case "move_left":
                    return new ActionBlock("move_left");
                case "move_right":
                    return new ActionBlock("move_right");
                case "move_center":
                    return new ActionBlock("move_center");
                case "move_closest_opponent":
                    return new ActionBlock("move_closest_opponent");

                case "approach_ennemy":
                    return new ActionBlock("approach_ennemy");
                case "flee_ennemy":
                    return new ActionBlock("flee_ennemy");
                case "attack_closest_ennemy":
                    return new ActionBlock("attack_closest_ennemy");
                case "attack_weakest_ennemy":
                    return new ActionBlock("attack_weakest_ennemy");
                case "attack_strongest_ennemy":
                    return new ActionBlock("attack_strongest_ennemy");

                case "wet_feet":
                    return new ActionBlock("wet_feet");
                case "current_hitpoints":
                    return new ActionBlock("current_hitpoints");
                case "ennemy_attack_range":
                    return new ActionBlock("ennemy_attack_range");
                case "can_move_forward":
                    return new ActionBlock("can_move_forward");
                case "can_move_backward":
                    return new ActionBlock("can_move_backward");
                case "can_move_left":
                    return new ActionBlock("can_move_left");
                case "can_move_right":
                    return new ActionBlock("can_move_right");

                case "math_number":




                    Field field = new Field()
                    {
                        Content = "",
                        FieldName = "",
                        FieldType = ""

                    };
                    return new FieldBlock("math_number", field);

            }



            XmlNodeList children = node.ChildNodes;

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
