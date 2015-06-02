using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    class IntermediateEvent : Event
    {
        public string typeEvent { get; set; }

        public IntermediateEvent(XElement elementActivity, XDocument xmlXDocument, List<Transition> transitions)
            : base(elementActivity, xmlXDocument, transitions)
            {
                typeEvent = getTypeEvent(elementActivity); 
            }

            public override void validate()
            {
            }


            private string getTypeEvent(XElement _elementActivity)
            {

                return "";
            }
    }
}
