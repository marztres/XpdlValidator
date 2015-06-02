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
                                return elementActivity.Attribute("Id").Value;
                            }
                         }
        public string name
        {
                                get
                                {
                                    return elementActivity.Attribute("Name").Value;
                                }
                            }
        public XElement elementActivity { get; set; } //XElement de la actividad.
        public XDocument xmlXDocument { get; set; } //Xml completo
        public string elementName {
                                get {
                                        return elementActivity.Name.LocalName;    
                                    }
                                  }
        public IEnumerable<Transition> transitions { get; set; }

        public Activity(XElement elementActivity, XDocument xmlXDocument)
        {
            this.elementActivity = elementActivity;
            this.xmlXDocument = xmlXDocument;
        }
        
        public abstract void validate();
    }
}
