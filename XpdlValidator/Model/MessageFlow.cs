using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class MessageFlow
    {
        public string Target
        {
            get
            {
                return XElementMessageFlow.Attribute("Target").Value;
            }
        }
        public string Source
        {
            get
            {
                return XElementMessageFlow.Attribute("Source").Value;
            }
        }

        private XElement XElementMessageFlow { get; set; } //XElement del MessageFlow.

        public MessageFlow(XElement xElementMessageFlow)
        {
            this.XElementMessageFlow = xElementMessageFlow;
        }

    }
}
