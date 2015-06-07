using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class Transition
    {
        public string To { 
                            get {
                                    return XElementTransition.Attribute("To").Value; 
                                } 
                         }
        public string From
                         {
                            get
                            {
                                return XElementTransition.Attribute("From").Value;
                            }
                         }

        private XElement XElementTransition { get; set; } //XElement de la transición.

        public Transition(XElement xElementTransition)
        {
            this.XElementTransition = xElementTransition;
        }

    }
}
