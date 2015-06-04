using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class MessageFlow
    {
        public string id
        {
            get
            {
                return xElementMessageFlow.Attribute("Id").Value;
            }
        }
        public string Target
        {
            get
            {
                return xElementMessageFlow.Attribute("Target").Value;
            }
        }
        public string source
        {
            get
            {
                return xElementMessageFlow.Attribute("Source").Value;
            }
        }
        public string name
        {
            get
            {
                return xElementMessageFlow.Attribute("Name").Value;
            }
        }

        public string elementName
        {
            get
            {
                return xElementMessageFlow.Name.LocalName;
            }
        }
        public XElement xElementMessageFlow { get; set; } //XElement del MessageFlow.

        public MessageFlow(XElement xElementMessageFlow)
        {
            this.xElementMessageFlow = xElementMessageFlow;
        }

    }
}
