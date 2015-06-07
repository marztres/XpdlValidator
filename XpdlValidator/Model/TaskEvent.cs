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
            this.TypeActivity = "Task";
        }

        public override IEnumerable<RuleException> Validate()
        {
            List<RuleException> rulesExceptions = new List<RuleException>();

            try
            {
                if (base.ExistStartOrEndEvent())
                    if (!(base.HasOutgoinSecuenceFlow()))
                        rulesExceptions.Add(new RuleException("This activity must have an outgoing sequence flow", XElementActivity, TypeActivity));
                
                IsActivityNameUnique();
            }
            catch (ApplicationException ex)
            {
                rulesExceptions.Add(new RuleException(ex.Message, XElementActivity, TypeActivity));
            }
            catch (Exception ex)
            {
                rulesExceptions.Add(new RuleException(ex.Message, XElementActivity, TypeActivity));
            }

            return rulesExceptions;
        }

        private void IsActivityNameUnique() 
        {
            IEnumerable<Activity> duplicateActivitiesName = base.Activities.Where(x => x.Id != this.Id && x.GetType() == typeof(TaskEvent) && !string.IsNullOrEmpty(x.Name) && x.Name == Name);

            const string errorMessage = " Two activities in the same process should not have the same name.";
            if (duplicateActivitiesName.Count() !=0)
            {
                throw new ApplicationException(errorMessage);
            }
        
        }

    }
}
