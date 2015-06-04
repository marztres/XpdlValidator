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
            this.typeActivity = "StartEvent";
        }

        public override List<RuleException> validate()
        {
            List<RuleException> rulesExceptions = new List<RuleException>();


            if (!(base.hasOutgoinSecuenceFlow()))
                rulesExceptions.Add(new RuleException("This startEvent must have an outgoing sequence flow", xElementActivity, xmlXDocument, typeActivity));    

            return rulesExceptions;
        }

    }
}
