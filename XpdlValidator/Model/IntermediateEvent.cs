using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    class IntermediateEvent : Event
    {
        private string TypeEvent
                                {
                                    get
                                    {
                                        return XElementActivity.Descendants().First(x => x.Name.LocalName == "IntermediateEvent").Attribute("Trigger").Value;
                                    }
                                }
        private IEnumerable<MessageFlow> FlowMessages { get; set; }
        private bool _isThrow = false;

        public IntermediateEvent(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Transition> transitions, IEnumerable<Activity> activities, IEnumerable<MessageFlow> flowMessages)
            : base(xElementActivity, xmlXDocument, transitions,activities)
            {
                GetAtributesByType();
                this.FlowMessages = flowMessages;
                this.TypeActivity = "IntermediateEvent";
            }

            public override IEnumerable<RuleException> Validate()
            {
                List<RuleException> rulesExceptions = new List<RuleException>();

                if (base.ExistStartOrEndEvent())
                    if (!(base.HasOutgoinSecuenceFlow()))
                        rulesExceptions.Add(new RuleException("This intermediate event should have an outgoing sequence flow", XElementActivity, TypeActivity));

                if (_isThrow && String.IsNullOrEmpty(this.Name))
                    rulesExceptions.Add(new RuleException(" A throwing intermediate event should be labeled.", XElementActivity, TypeActivity));

                if (TypeEvent == "Message" && !_isThrow)
                    if (!(HasIncomingMessageFlow()))
                        rulesExceptions.Add(new RuleException(" A catching Message event should have incoming message flow.", XElementActivity, TypeActivity));

                if (TypeEvent != "Message" || !_isThrow) return rulesExceptions;
                if (!(HasOutgoingMessageFlow()))
                    rulesExceptions.Add(new RuleException(" A throwing Message event should have outgoing message flow.", XElementActivity, TypeActivity));

                return rulesExceptions;
            }

        private void GetAtributesByType()
        {
            if (XElementActivity.Descendants().Count(x => x.Name.LocalName == "TriggerResultMessage") == 0) return;
            if (
                XElementActivity.Descendants()
                    .First(x => x.Name.LocalName == "TriggerResultMessage")
                    .Attribute("CatchThrow") == null) return;
            if (XElementActivity.Descendants().First(x => x.Name.LocalName == "TriggerResultMessage").Attribute("CatchThrow").Value == "THROW")
                _isThrow = true;
        }

        private bool HasOutgoingMessageFlow()
            {
                IEnumerable<MessageFlow> outgoingMessageFlow = this.FlowMessages.Where(x => x.Source == this.Id);

                return outgoingMessageFlow.Count() != 0;
            }

        private bool HasIncomingMessageFlow()
            {
                IEnumerable<MessageFlow> incomingMessageFlow = this.FlowMessages.Where(x => x.Target == this.Id);
                return incomingMessageFlow.Any();
            }
    }
}
