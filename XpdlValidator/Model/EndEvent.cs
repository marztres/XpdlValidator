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
            this.typeActivity = "EndEvent";
        }

        public override List<RuleException> validate()
        {
            List<RuleException> rulesExceptions = new List<RuleException>();

            if (!(base.hasIncomingSecuenceFlow()))
                rulesExceptions.Add(new RuleException("End event must have an incoming sequence flow.", xElementActivity, xmlXDocument,typeActivity));

            return rulesExceptions;
        }

    }
}
