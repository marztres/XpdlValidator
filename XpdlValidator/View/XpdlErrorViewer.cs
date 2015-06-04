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
using XpdlValidator.Utility;

namespace XpdlValidator.View
{
    public partial class XpdlErrorViewer : Form
    {
        public XpdlErrorViewer()
        {
            InitializeComponent();
        }

        private ValidatorXpdl validatorXpdl;
        private XDocument xmlXDocument;

        public XpdlErrorViewer(XDocument xmlXDocument) 
        {
            InitializeComponent();

            this.xmlXDocument = xmlXDocument;
        }

        private void XpdlErrorViewer_Load(object sender, EventArgs e)
        {
            txtXmlViewer.Text = DocumentExtensions.BeautifyXml(xmlXDocument.ToXmlDocument());
            
            validatorXpdl = new ValidatorXpdl(xmlXDocument);

            cargarErrores();
        }


        private void cargarErrores() 
        {
            
            gvErrores.DataSource = validatorXpdl.rulesExceptions.Select(ruleException => new { errorIcon = getImageError(), ruleException.Message,  ruleException.id, ruleException.name, ruleException.typeActivity, ruleException.XPath }).ToList();

            estilosGridview();
        }

        private void estilosGridview() 
        {
            gvErrores.Columns[0].HeaderText = "Error";
            gvErrores.Columns[1].HeaderText = "Message";
            gvErrores.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gvErrores.Columns[2].HeaderText = "Id";
            gvErrores.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gvErrores.Columns[3].HeaderText = "Name";
            gvErrores.Columns[4].HeaderText = "Type";
            gvErrores.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gvErrores.Columns[5].HeaderText = "Xpath";
            gvErrores.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gvErrores.Columns[6].HeaderText = "Details";
        }

        private Image getImageError()
        {
            string assets = AppDomain.CurrentDomain.BaseDirectory + "Assets\\";

            return Image.FromFile(assets + "error.png");
        }

        private void gvErrores_Paint(object sender, PaintEventArgs e)
        {
            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.White, new Rectangle(new Point(), new Size(sndr.Width, 25)));
                    // write text on top of the white rectangle just created
                    grfx.DrawString("XPDL file without errors.", new Font("Open sans", 14, FontStyle.Bold), Brushes.Black, new PointF(3, 3));
                }
            }
        }
    }
}
