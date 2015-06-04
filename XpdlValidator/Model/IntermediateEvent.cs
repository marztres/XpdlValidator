using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    class IntermediateEvent : Event
    {
        public string typeEvent
                                {
                                    get
                                    {
                                        return xElementActivity.Descendants().Where(X => X.Name.LocalName == "IntermediateEvent").First().Attribute("Trigger").Value;
                                    }
                                }
        public Boolean isThrow = false;

        public IntermediateEvent(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities)
            : base(xElementActivity, xmlXDocument, transitions,activities)
            {
                getAtributesByType();
            }

            public override void validate()
            {
                if (isThrow && String.IsNullOrEmpty(this.name))
                {
                    MessageBox.Show(" No cumple la regla Style 0115. nombre : " + this.xElementName);
                }
            }

            protected void getAtributesByType() 
            {
                if (xElementActivity.Descendants().Where(X => X.Name.LocalName == "TriggerResultMessage").Count() != 0)
                    if (xElementActivity.Descendants().Where(X => X.Name.LocalName == "TriggerResultMessage").First().Attribute("CatchThrow") != null)
                        if (xElementActivity.Descendants().Where(X => X.Name.LocalName == "TriggerResultMessage").First().Attribute("CatchThrow").Value == "THROW")
                            isThrow = true;
                
            }

           
    }
}
