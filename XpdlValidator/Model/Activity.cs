using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{

    public abstract class Activity
    {
        public string Id
                        {
                            get
                            {
                                return XElementActivity.Attribute("Id").Value;
                            }
                         }
        public string Name
                        {
                            get
                            {
                                return XElementActivity.Attribute("Name").Value;
                            }
                        }

        protected XElement XElementActivity { get; private set; }

        protected IEnumerable<Transition> Transitions { private get; set; }
        protected IEnumerable<Activity> Activities { get; private set; }
        protected string TypeActivity { get; set; }

        protected Activity(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Activity> activities)
        {
            this.XElementActivity = xElementActivity;
            this.Activities = activities;
        }
        
        public abstract IEnumerable<RuleException> Validate();

        protected bool HasOutgoinSecuenceFlow()
        {
            IEnumerable<Transition> outSecuenceFlow = Transitions.Where(x=> x.From == this.Id);

            return outSecuenceFlow.Count() != 0;
        }

        protected bool HasIncomingSecuenceFlow()
        {
            IEnumerable<Transition> incomingSecuenceFlow = Transitions.Where(x => x.To == this.Id);

            return incomingSecuenceFlow.Any();
        }

        protected bool ExistStartOrEndEvent()
        {
            IEnumerable<Activity> startOrEndEvent = this.Activities.Where(x => x.GetType() == typeof(StartEvent) || x.GetType() == typeof(EndEvent));

            return startOrEndEvent.Count() != 0;
        }
    }
}
