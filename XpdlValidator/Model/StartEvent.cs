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
        public StartEvent(XElement elementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
            : base(elementActivity,xmlXDocument,transitions,activities)
        {
            this.TypeActivity = "StartEvent";
        }

        public override IEnumerable<RuleException> Validate()
        {
            List<RuleException> rulesExceptions = new List<RuleException>();


            if (!(base.HasOutgoinSecuenceFlow()))
                rulesExceptions.Add(new RuleException("This startEvent must have an outgoing sequence flow", XElementActivity, TypeActivity));    

            return rulesExceptions;
        }

    }
}
