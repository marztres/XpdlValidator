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
            this.typeActivity = "Task";
        }

        public override List<RuleException> validate()
        {
            List<RuleException> rulesExceptions = new List<RuleException>();

            try
            {
                if (base.existStartOrEndEvent())
                    if (!(base.hasOutgoinSecuenceFlow()))
                        rulesExceptions.Add(new RuleException("This activity must have an outgoing sequence flow", xElementActivity, xmlXDocument, typeActivity));
                
                isActivityNameUnique();
            }
            catch (ApplicationException ex)
            {
                rulesExceptions.Add(new RuleException(ex.Message, xElementActivity, xmlXDocument, typeActivity));
            }
            catch (Exception ex)
            {
                rulesExceptions.Add(new RuleException(ex.Message, xElementActivity, xmlXDocument, typeActivity));
            }

            return rulesExceptions;
        }

        private void isActivityNameUnique() 
        {
            IEnumerable<Activity> duplicateActivitiesName = base.activities.Where(X => X.id != this.id && X.GetType() == typeof(TaskEvent) && !String.IsNullOrEmpty(X.name) && X.name == name);

            if (duplicateActivitiesName.Count() !=0)
            {
                string errorMessage = " Two activities in the same process should not have the same name.";

                throw new ApplicationException(errorMessage);
            }
        
        }

    }
}
