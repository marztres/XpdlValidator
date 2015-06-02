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
        public string id { get; set; }
        public string name { get; set; }
        public string to { 
                            get {
                                    return elementTransition.Attribute("To").Value; 
                                } 
                         }
        public string from
                         {
                            get
                            {
                                return elementTransition.Attribute("From").Value;
                            }
                         }
        public string elementName
        {
            get
            {
                return elementTransition.Name.LocalName;
            }
        }
        public XElement elementTransition { get; set; } //XElement de la transición.

        public Transition(XElement elementTransition) 
        {
            this.elementTransition = elementTransition;
        }
    }
}
