using System.Xml.Linq;

namespace XpdlValidator.Model
{
    /// <summary>
    /// Model of a BPMN message Flow
    /// </summary>
    public class MessageFlow
    {
        public string Target
        {
            get
            {
                return XElementMessageFlow.Attribute("Target") != null ? XElementMessageFlow.Attribute("Target").Value : string.Empty;                
            }
        }
        public string Source
        {
            get
            {
                return XElementMessageFlow.Attribute("Source") != null ? XElementMessageFlow.Attribute("Source").Value : string.Empty;
            }
        }

        private XElement XElementMessageFlow { get; set; } //XElement MessageFlow.

        public MessageFlow(XElement xElementMessageFlow)
        {
            this.XElementMessageFlow = xElementMessageFlow;
        }

    }
}
