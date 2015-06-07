using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public abstract class Event : Activity
    {
        protected Event(XElement elementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
            : base(elementActivity, xmlXDocument,activities) 
        {
            this.Transitions = transitions.Where(x => x.To == this.Id || x.From == this.Id);
        }
    }
}
