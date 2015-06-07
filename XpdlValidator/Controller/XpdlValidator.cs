using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XpdlValidator.Model;



namespace XpdlValidator.Controller
{
    public class ValidatorXpdl
    {
        public readonly List<RuleException> RulesExceptions  = new List<RuleException>();

        public ValidatorXpdl(XDocument xmlXDocument) 
        {
            if (xmlXDocument.Root != null)
            {
                XNamespace  xDocumentNameSpace = xmlXDocument.Root.GetDefaultNamespace();

                IEnumerable<XElement> xElementActivities = from activity in xmlXDocument.Root.Descendants(xDocumentNameSpace + "Activity") select activity;
                IEnumerable<Transition> transitions = from transition in xmlXDocument.Root.Descendants(xDocumentNameSpace + "Transition") select new Transition((XElement)transition) ;
                IEnumerable<MessageFlow> flowMessages = from messageFlow in xmlXDocument.Root.Descendants(xDocumentNameSpace + "MessageFlow") select new MessageFlow((XElement)messageFlow);
                List<Activity> activities = new List<Activity>();

                foreach (XElement xElementActivity in xElementActivities)
                {
                    Activity activity = getActivity(xElementActivity, xmlXDocument, transitions, activities, flowMessages);
                    activities.Add(activity);
                }

                foreach (Activity activity in activities)
                {
                    IEnumerable<RuleException> validationExceptions = activity.Validate();

                    foreach (RuleException ruleException in validationExceptions)
                    {
                        RulesExceptions.Add(ruleException);
                    }
                }
            }
        }

        public Activity getActivity(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities, IEnumerable<MessageFlow> flowMessages)
        {
            List<string> typesActivities = new List<string>() { "Implementation", "Event" };

            IEnumerable<XElement> typeActivity = from tipo in xElementActivity.Elements()
                                                 where typesActivities.Contains((string)tipo.Name.LocalName)
                                                 select tipo;

            XElement[] xElements = typeActivity as XElement[] ?? typeActivity.ToArray();
            if (xElements.First().Name.LocalName == "Event")
            {
                List<string> typesEvents = new List<string>() { "StartEvent", "IntermediateEvent", "EndEvent" };

                IEnumerable<XElement> typeEvent = from tipo in xElements.Elements() 
                                                  where typesEvents.Contains((string)tipo.Name.LocalName)
                                                  select tipo;
                XElement[] enumerable = typeEvent as XElement[] ?? typeEvent.ToArray();
                switch (enumerable.First().Name.LocalName)
                {
                    case "StartEvent":
                        return new StartEvent(xElementActivity, xmlXDocument, transitions,activities);
                    case "IntermediateEvent":
                        return new IntermediateEvent(xElementActivity, xmlXDocument, transitions,activities,flowMessages);
                    default:
                        return new EndEvent(xElementActivity, xmlXDocument, transitions,activities);
                }
            }
            else
            {
                return new TaskEvent(xElementActivity, xmlXDocument, transitions, activities);
            }
        }

    }
}
