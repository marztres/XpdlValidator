using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{

    public abstract class Activity
    {
        public string Id
                        {
                            get
                            {
                                return XElementActivity.Attribute("Id").Value;
                            }
                         }
        public string Name
                        {
                            get
                            {
                                return XElementActivity.Attribute("Name").Value;
                            }
                        }

        protected XElement XElementActivity { get; private set; }

        protected IEnumerable<Transition> Transitions { private get; set; }
        protected IEnumerable<Activity> Activities { get; private set; }
        protected string TypeActivity { get; set; }
        public string IdProcess { get; private set; }

        /// <summary>
        /// Constructor of Activity
        /// </summary>
        /// <param name="xElementActivity"> XElement of the BPMN Object  </param>
        /// <param name="xmlXDocument"> Fully XmlDocument </param>
        /// <param name="activities"> List of Activities </param>
        protected Activity(XElement xElementActivity, XDocument xmlXDocument, IEnumerable<Activity> activities)
        {
            this.XElementActivity = xElementActivity;
            this.Activities = activities;
            IdProcess = GetProcess();
        }
        
        /// <summary>
        /// Abstrac method for validate BPMN Rules for each type of BPMN objects.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<RuleException> Validate();

        /// <summary>
        /// Determine if the activity has an Out going Secuence Flow
        /// </summary>
        /// <returns> true if the event has an Out going Secuence Flow  </returns>
        protected bool HasOutgoingSecuenceFlow()
        {
            return Transitions.Any(x=> x.From == this.Id);
        }

        /// <summary>
        /// Determine if the activity has an Incoming Secuence Flow
        /// </summary>
        /// <returns> true if the event has an Incoming Secuence Flow  </returns>
        protected bool HasIncomingSecuenceFlow()
        {
            return Transitions.Any(x => x.To == this.Id);
        }

        /// <summary>
        /// Determine if exists a start event or End event
        /// </summary>
        /// <returns> true if there is a start event or End Event  </returns>
        protected bool ExistStartOrEndEvent()
        {
            return this.Activities.Any(x => x.GetType() == typeof(StartEvent) || x.GetType() == typeof(EndEvent));
        }

        /// <summary>
        /// Get the proccess id of the activity
        /// </summary>
        /// <returns> string IdProcess </returns>
        private string GetProcess()
        {
            return XElementActivity.Ancestors().First(x => x.Name.LocalName == "WorkflowProcess").Attribute("Id").Value;
        }
    }
}
