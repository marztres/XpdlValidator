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

            IEnumerable<XElement> activities = from activity in xmlXDocument.Root.Descendants(XDocumentNameSpace + "Activity") select activity;
            List<Transition> transitions = xmlXDocument.Root.Descendants(XDocumentNameSpace + "Transition").Select(X => new Transition { elementTransition = (XElement)X }).ToList();

            foreach (XElement elementActivity in activities)
            {
                //Activity activity = getActivity(nodeActivity, documentoXpdl.Root.Descendants(), idPool, namePool, proccessId);
            }

        }

        public Activity getActivity(XElement elementActivity, XDocument xmlXDocument)
        {
            Activity activity;
            
            List<string> typesActivities = new List<string>() { "Implementation", "Event" };

            IEnumerable<XElement> typeActivity = from tipo in elementActivity.Elements()
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
                    activity = new StartEvent(elementActivity,xmlXDocument);
                }
                else if (typeEvent.First().Name.LocalName == "IntermediateEvent")
                {
                    activity = new IntermediateEvent(idActivity, nameActivity, elementsXpdl, nodeActivity, idPool, namePool, proccessId);
                }
                else
                {
                    activity = new EndEvent(idActivity, nameActivity, elementsXpdl, nodeActivity, idPool, namePool, proccessId);
                }
            }
            else
            {
                activity = new TaskEvent(idActivity, nameActivity, elementsXpdl, nodeActivity, idPool, namePool, proccessId);
            }

            return activity;
        }




    }
}
