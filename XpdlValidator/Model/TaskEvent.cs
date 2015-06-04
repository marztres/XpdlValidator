using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class TaskEvent : Event
    {
        public TaskEvent(XElement elementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
            : base(elementActivity, xmlXDocument, transitions,activities)
        {
        }

        public override void validate()
        {
            if (existStartOrEndEvent())
                hasOutgoinSecuenceFlow();
        }

        private Boolean existStartOrEndEvent() 
        {
            IEnumerable<Activity> startOrEndEvent = base.activities.Where(X => X.GetType() == typeof(StartEvent) || X.GetType() == typeof(EndEvent));

            if (startOrEndEvent.Count() >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }  
        }

    }
}
