using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public abstract class Activity
    {
        public string id
                        {
                            get
                            {
                                return xElementActivity.Attribute("Id").Value;
                            }
                         }
        public string name
                        {
                            get
                            {
                                return xElementActivity.Attribute("Name").Value;
                            }
                        }
        public XElement xElementActivity { get; set; } //XElement de la actividad.
        public XDocument xmlXDocument { get; set; } //Xml completo
        public string xElementName {
                                get {
                                        return xElementActivity.Name.LocalName;    
                                    }
                                  }
        public IEnumerable<Transition> transitions { get; set; }
        public IEnumerable<Activity> activities { get; set; }
        public string typeActivity { get; set; }

        public Activity(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Activity> activities)
        {
            this.xElementActivity = xElementActivity;
            this.xmlXDocument = xmlXDocument;
            this.activities = activities;
        }
        
        public abstract List<RuleException> validate();

        protected virtual Boolean hasOutgoinSecuenceFlow() 
        {
            IEnumerable<Transition> outSecuenceFlow = transitions.Where(X=> X.from == this.id);

            if (outSecuenceFlow.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;               
            }
        }

        protected virtual Boolean hasIncomingSecuenceFlow()
        {
            IEnumerable<Transition> incomingSecuenceFlow = transitions.Where(X => X.to == this.id);

            if (incomingSecuenceFlow.Count() == 0)
                return false;
            else
                return true;
        }

        protected Boolean existStartOrEndEvent()
        {
            IEnumerable<Activity> startOrEndEvent = this.activities.Where(X => X.GetType() == typeof(StartEvent) || X.GetType() == typeof(EndEvent));

            if (startOrEndEvent.Count() != 0)
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
