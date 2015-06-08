using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    /// <summary>
    /// Model of an Event
    /// </summary>
    public abstract class Event : Activity
    {
        protected Event(XElement elementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
            : base(elementActivity, xmlXDocument,activities) 
        {
            //Select the transitions that are conect to the event.
            this.Transitions = transitions.Where(x => x.To == this.Id || x.From == this.Id);
        }
    }
}
