using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class EndEvent : Event
    {
        public EndEvent(XElement elementActivity, XDocument xmlXDocument, List<Transition> transitions)
            : base(elementActivity, xmlXDocument, transitions)
        {
        }

        public override void validate()
        {
        }

    }
}
