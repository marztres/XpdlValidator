using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    /// <summary>
    /// Model of a BPMN Task 
    /// </summary>
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
                if (ExistStartOrEndEvent())
                    if (!(HasOutgoingSecuenceFlow()))
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

        /// <summary>
        /// Look for duplicate name in the same process 
        /// Raise Exception  if It was found at least  one.
        /// </summary>
        private void IsActivityNameUnique() 
        {
            IEnumerable<Activity> duplicateActivitiesName = Activities.Where(x => x.Id != this.Id && x.GetType() == typeof(TaskEvent) && !string.IsNullOrEmpty(x.Name) && x.Name == Name);

            const string errorMessage = " Two activities in the same process should not have the same name.";
            var activitiesName = duplicateActivitiesName as Activity[] ?? duplicateActivitiesName.ToArray();
            if (activitiesName.Any(activity => activity.IdProcess == IdProcess))
            {
                throw new ApplicationException(errorMessage);
            }
        }    
    }
}
