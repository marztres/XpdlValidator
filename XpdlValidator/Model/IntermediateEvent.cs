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
        public IEnumerable<MessageFlow> flowMessages { get; set; }

        public IntermediateEvent(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities, IEnumerable<MessageFlow> flowMessages)
            : base(xElementActivity, xmlXDocument, transitions,activities)
            {
                getAtributesByType();
                this.flowMessages = flowMessages;
                this.typeActivity = "IntermediateEvent";
            }

            public override List<RuleException> validate()
            {
                List<RuleException> rulesExceptions = new List<RuleException>();

                if (base.existStartOrEndEvent())
                    if (!(base.hasOutgoinSecuenceFlow()))
                        rulesExceptions.Add(new RuleException("This intermediate event should have an outgoing sequence flow", xElementActivity, xmlXDocument, typeActivity));

                if (isThrow && String.IsNullOrEmpty(this.name))
                    rulesExceptions.Add(new RuleException(" A throwing intermediate event should be labeled.", xElementActivity, xmlXDocument, typeActivity));

                if (typeEvent == "Message" && !isThrow)
                    if (!(hasIncomingMessageFlow()))
                        rulesExceptions.Add(new RuleException(" A catching Message event should have incoming message flow.", xElementActivity, xmlXDocument, typeActivity));

                if (typeEvent == "Message" && isThrow)
                    if (!(hasOutgoingMessageFlow()))
                        rulesExceptions.Add(new RuleException(" A throwing Message event should have outgoing message flow.", xElementActivity, xmlXDocument, typeActivity));

                return rulesExceptions;
            }

            protected void getAtributesByType() 
            {
                if (xElementActivity.Descendants().Where(X => X.Name.LocalName == "TriggerResultMessage").Count() != 0)
                    if (xElementActivity.Descendants().Where(X => X.Name.LocalName == "TriggerResultMessage").First().Attribute("CatchThrow") != null)
                        if (xElementActivity.Descendants().Where(X => X.Name.LocalName == "TriggerResultMessage").First().Attribute("CatchThrow").Value == "THROW")
                            isThrow = true;                
            }

            private Boolean hasOutgoingMessageFlow()
            {
                IEnumerable<MessageFlow> outgoingMessageFlow = this.flowMessages.Where(X => X.source == this.id);

                if (outgoingMessageFlow.Count() != 0)                
                    return true;                
                else                
                    return false;                
            }

            private Boolean hasIncomingMessageFlow()
            {
                IEnumerable<MessageFlow> incomingMessageFlow = this.flowMessages.Where(X => X.Target == this.id);
                if (incomingMessageFlow.Count() == 0)
                    return false;
                else
                    return true;
            }
            
    }
}
