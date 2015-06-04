using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Activity(XElement elementActivity, XDocument xmlXDocument, IEnumerable<Activity> activities)
        {
            this.xElementActivity = elementActivity;
            this.xmlXDocument = xmlXDocument;
            this.activities = activities;
        }
        
        public abstract void validate();
    }
}
