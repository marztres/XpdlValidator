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
        public ValidatorXpdl(XDocument xmlXDocument) 
        {
            XNamespace  XDocumentNameSpace = xmlXDocument.Root.GetDefaultNamespace();

            IEnumerable<XElement> xElementActivities = from activity in xmlXDocument.Root.Descendants(XDocumentNameSpace + "Activity") select activity;
            IEnumerable<Transition> transitions = from transition in xmlXDocument.Root.Descendants(XDocumentNameSpace + "Transition") select new Transition((XElement)transition) ;
            List<Activity> activities = new List<Activity>();

            foreach (XElement xElementActivity in xElementActivities)
            {
                Activity activity = getActivity(xElementActivity, xmlXDocument, transitions, activities);
                activities.Add(activity);
                activity.validate();
            }

        }

        public Activity getActivity(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
        {
            Activity activity;
            
            List<string> typesActivities = new List<string>() { "Implementation", "Event" };

            IEnumerable<XElement> typeActivity = from tipo in xElementActivity.Elements()
                                                 where typesActivities.Contains((string)tipo.Name.LocalName)
                                                 select tipo;

            if (typeActivity.First().Name.LocalName == "Event")
            {
                List<string> typesEvents = new List<string>() { "StartEvent", "IntermediateEvent", "EndEvent" };

                IEnumerable<XElement> typeEvent = from tipo in typeActivity.Elements() 
                                                  where typesEvents.Contains((string)tipo.Name.LocalName)
                                                  select tipo;
                if (typeEvent.First().Name.LocalName == "StartEvent")
                {
                    return activity = new StartEvent(xElementActivity, xmlXDocument, transitions,activities);
                }
                else if (typeEvent.First().Name.LocalName == "IntermediateEvent")
                {
                    return activity = new IntermediateEvent(xElementActivity, xmlXDocument, transitions,activities);
                }
                else
                {
                    return activity = new EndEvent(xElementActivity, xmlXDocument, transitions,activities);
                }
            }
            else
            {
                return activity = new TaskEvent(xElementActivity, xmlXDocument, transitions, activities);
            }
        }




    }
}
