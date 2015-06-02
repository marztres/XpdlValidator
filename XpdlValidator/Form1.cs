using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XpdlValidator.Model;

namespace XpdlValidator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string directorioBase = AppDomain.CurrentDomain.BaseDirectory + "xpdl_files\\";


        private void button1_Click(object sender, EventArgs e)
        {
            XDocument documentoXpdl = XDocument.Load(directorioBase + "Sample 1.xpdl");

            XNamespace xpdlNameSpace = documentoXpdl.Root.GetDefaultNamespace();

            IEnumerable<XElement> poolsActivos = from pool in documentoXpdl.Root.Elements(xpdlNameSpace + "Pools").First().Elements(xpdlNameSpace + "Pool").Where(X => (string)X.Attribute("BoundaryVisible").Value == "true") select pool;

            foreach (XElement pool in poolsActivos)
            {
                string idPool = pool.Attribute("Id").Value;
                string namePool = pool.Attribute("Name").Value;
                string proccessId = pool.Attribute("Process").Value;

                IEnumerable<XElement> activities = from activity in documentoXpdl.Root.Elements(xpdlNameSpace + "WorkflowProcesses").First().Elements(xpdlNameSpace + "WorkflowProcess").Elements(xpdlNameSpace + "Activities").Elements(xpdlNameSpace + "Activity") select activity;

                foreach (XElement nodeActivity in activities)
                {
                    Activity activity = getActivity(nodeActivity, documentoXpdl.Root.Descendants(), idPool, namePool, proccessId);
                }
            }
        }

        public Activity getActivity(XElement nodeActivity, IEnumerable<XElement> elementsXpdl,string idPool,string namePool,string proccessId)
        {
            Activity  activity;
            string idActivity = nodeActivity.Attribute("Id").Value;
            string nameActivity = nodeActivity.Attribute("Name").Value;
            
            List<string> typesActivities = new List<string>() { "Implementation", "Event"};

            IEnumerable<XElement> typeActivity = from tipo in nodeActivity.Elements()
                                                  where typesActivities.Contains((string)tipo.Name.LocalName)
                                                  select tipo;

            if (typeActivity.First().Name.LocalName == "Event")
            {
                List<string> typesEvents = new List<string>() { "StartEvent", "IntermediateEvent","EndEvent"};

                IEnumerable<XElement> typeEvent = from tipo in typeActivity.Elements()
                                                  where typesEvents.Contains((string)tipo.Name.LocalName)
                                                  select tipo;
                if (typeEvent.First().Name.LocalName == "StartEvent")
                {
                    activity = new StartEvent(idActivity, nameActivity, elementsXpdl, nodeActivity, idPool, namePool, proccessId);
                }
                else if (typeEvent.First().Name.LocalName == "IntermediateEvent")
                {
                    activity = new IntermediateEvent(idActivity, nameActivity, elementsXpdl, nodeActivity, idPool, namePool, proccessId);
                } else
	            {
                    activity = new EndEvent(idActivity, nameActivity, elementsXpdl, nodeActivity, idPool, namePool, proccessId);
	            }
            }
            else
            {
                activity = new TaskEvent(idActivity, nameActivity, elementsXpdl, nodeActivity, idPool, namePool, proccessId);
            }

            return activity;
        }

    }
}
