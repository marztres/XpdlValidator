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
        public EndEvent(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
            : base(xElementActivity, xmlXDocument, transitions,activities)
        {
        }

        public override void validate()
        {
        }

    }
}
