using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class StartEvent : Event
    {
        public StartEvent(XElement elementActivity, XDocument xmlXDocument, List<Transition> transitions)
            : base(elementActivity,xmlXDocument,transitions)
        {
        }

        public override void validate() 
        {
        }

    }
}
