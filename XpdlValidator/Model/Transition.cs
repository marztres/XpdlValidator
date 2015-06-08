using System;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    /// <summary>
    /// Model of a BPMN Transition
    /// </summary>
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

        private XElement XElementTransition { get; set; } // XElement of the transition

        public Transition(XElement xElementTransition)
        {
            this.XElementTransition = xElementTransition;
        }

    }
}
