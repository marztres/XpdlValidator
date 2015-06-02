using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public abstract class Event : Activity
    {
        public Event(XElement elementActivity, XDocument xmlXDocument,List<Transition> transitions) : base(elementActivity, xmlXDocument) 
        {
            this.transitions = transitions.Where(X => X.to == this.id || X.from == this.id);
        }
    }
}
