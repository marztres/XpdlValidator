using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    class TaskEvent : Event
    {
        public IEnumerable<TaskEvent> taskEvents;
        public TaskEvent(XElement elementActivity, XDocument xmlXDocument, List<Transition> transitions, List<TaskEvent> taskEvents)
            : base(elementActivity, xmlXDocument, transitions)
        {
            this.taskEvents = taskEvents.Where(X => X.id != this.id);
        }

        public override void validate()
        {
        }
    }
}
