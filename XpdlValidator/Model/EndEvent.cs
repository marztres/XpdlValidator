using System.Collections.Generic;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class EndEvent : Event
    {
        public EndEvent(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
            : base(xElementActivity, xmlXDocument, transitions,activities)
        {
            this.TypeActivity = "EndEvent";
        }

        public override IEnumerable<RuleException> Validate()
        {
            List<RuleException> rulesExceptions = new List<RuleException>();

            if (!(base.HasIncomingSecuenceFlow()))
                rulesExceptions.Add(new RuleException("End event must have an incoming sequence flow.", XElementActivity,TypeActivity));

            return rulesExceptions;
        }

    }
}
