using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class Transition
    {
        public string id
        {
            get
            {
                return xElementTransition.Attribute("Id").Value;
            }
        }
        public string to { 
                            get {
                                    return xElementTransition.Attribute("To").Value; 
                                } 
                         }
        public string from
                         {
                            get
                            {
                                return xElementTransition.Attribute("From").Value;
                            }
                         }
        public string elementName
        {
            get
            {
                return xElementTransition.Name.LocalName;
            }
        }
        public XElement xElementTransition { get; set; } //XElement de la transición.

        public Transition(XElement xElementTransition)
        {
            this.xElementTransition = xElementTransition;
        }

    }
}
