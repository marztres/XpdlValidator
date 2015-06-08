using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    /// <summary>
    /// Model of BPMN Intermediate event
    /// </summary>
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
                IsEventThrow();
                this.FlowMessages = flowMessages;
                this.TypeActivity = "IntermediateEvent";
            }

            public override IEnumerable<RuleException> Validate()
            {
                List<RuleException> rulesExceptions = new List<RuleException>();

                if (base.ExistStartOrEndEvent())
                    if (!(base.HasOutgoingSecuenceFlow()))
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
        /// <summary>
        /// Determine if the intermediate message event is Throw
        /// </summary>
        private void IsEventThrow()
        {
            if (XElementActivity.Descendants().Count(x => x.Name.LocalName == "TriggerResultMessage") == 0) return;
            if (
                XElementActivity.Descendants()
                    .First(x => x.Name.LocalName == "TriggerResultMessage")
                    .Attribute("CatchThrow") == null) return;
            if (XElementActivity.Descendants().First(x => x.Name.LocalName == "TriggerResultMessage").Attribute("CatchThrow").Value == "THROW")
                _isThrow = true;
        }

        /// <summary>
        /// Determine if the intermediate event has  Outgoing Message Flow
        /// </summary>
        /// <returns> true if the event has an Outgoing Message Flow  </returns>
        private bool HasOutgoingMessageFlow()
            {
                return this.FlowMessages.Any(x => x.Source == this.Id);
            }
        /// <summary>
        /// Determine if the intermediate event has Incoming Message Flow 
        /// </summary>
        /// <returns> true if the event has an Incoming Message Flow  </returns>
        private bool HasIncomingMessageFlow()
            {
                return this.FlowMessages.Any(x => x.Target == this.Id);
            }
    }
}
