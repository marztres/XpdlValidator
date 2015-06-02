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
using XpdlValidator.Controller;


namespace XpdlValidator.View
{
    public partial class XpdlErrorViewer : Form
    {
        public XpdlErrorViewer()
        {
            InitializeComponent();
        }

        ValidatorXpdl validatorXpdl;
        XDocument xmlXDocument;

        public XpdlErrorViewer(XDocument xmlXDocument) 
        {
            this.xmlXDocument = xmlXDocument;
            validatorXpdl = new ValidatorXpdl(xmlXDocument);
        }

        private void XpdlErrorViewer_Load(object sender, EventArgs e)
        {
        }


    }
}
