using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using XpdlValidator.Controller;
using XpdlValidator.Model;
using XpdlValidator.Utility;

namespace XpdlValidator.View
{
    public partial class XpdlErrorViewer : Form
    {
        public XpdlErrorViewer()
        {
            InitializeComponent();
        }

        private ValidatorXpdl _validatorXpdl;
        private readonly XDocument xmlXDocument;

        public XpdlErrorViewer(XDocument xmlXDocument) 
        {
            InitializeComponent();

            this.xmlXDocument = xmlXDocument;
        }

        private void XpdlErrorViewer_Load(object sender, EventArgs e)
        {
            txtXmlViewer.Text = DocumentExtensions.BeautifyXml(xmlXDocument.ToXmlDocument());
            
            _validatorXpdl = new ValidatorXpdl(xmlXDocument);

            CargarErrores();
        }


        private void CargarErrores() 
        {
            gvErrores.DataSource = _validatorXpdl.RulesExceptions.Select(ruleException => new { errorIcon = getImageError(), ruleException.Message, id = ruleException.Id, name = ruleException.Name, typeActivity = ruleException.TypeActivity, ruleException.XPath, exception = ruleException }).ToList();

            EstilosGridview();
        }

        private void EstilosGridview() 
        {

            DataGridViewButtonColumn buttonColumn =
                new DataGridViewButtonColumn
                {
                    HeaderText = "Info",
                    Name = "Info",
                    Text = "Info",
                    UseColumnTextForButtonValue = true
                };

            gvErrores.Columns.Add(buttonColumn);

            gvErrores.Columns[0].HeaderText = ".";
            gvErrores.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            gvErrores.Columns[1].HeaderText = "Message";
            gvErrores.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            gvErrores.Columns[2].HeaderText = "Id";
            gvErrores.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gvErrores.Columns[3].HeaderText = "Name";
            gvErrores.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gvErrores.Columns[4].HeaderText = "Type";
            gvErrores.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gvErrores.Columns[5].HeaderText = "Xpath";
            gvErrores.Columns[6].Visible = false;

            gvErrores.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
           
        }

        private Image getImageError()
        {
            string assets = AppDomain.CurrentDomain.BaseDirectory + "Assets\\";

            return Image.FromFile(assets + "error.png");
        }

        private void gvErrores_Paint(object sender, PaintEventArgs e)
        {
            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count != 0) return;
            using (Graphics grfx = e.Graphics)
            {
                // create a white rectangle so text will be easily readable
                grfx.FillRectangle(Brushes.White, new Rectangle(new Point(), new Size(sndr.Width, 50)));
                // write text on top of the white rectangle just created
                grfx.DrawString("XPDL file without errors.", new Font("Open sans", 16, FontStyle.Bold), Brushes.Black, new PointF(3, 3));
            }
        }

        private void gvErrores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 7) return;
            RuleException ruleException = (RuleException)gvErrores.Rows[e.RowIndex].Cells[6].Value;

            RuleExceptionDetail(ruleException);
        }
        
        /// <summary>
        /// Get details from a BPMN rule exception
        /// </summary>
        /// <param name="ruleException"> BPMN Object rule exception </param>
        private void RuleExceptionDetail(RuleException ruleException)
        {            
            XmlDocument xmlDocument = new XmlDocument();            
            xmlDocument.LoadXml(ruleException.XElement.ToString());

            string detalleError = " Id : " +ruleException.Id + Environment.NewLine + " Name : " +ruleException.Name + Environment.NewLine + " Message : " +ruleException.Message + Environment.NewLine + " Xpath : " + ruleException.XPath + Environment.NewLine + " Elemento Xml : " + Environment.NewLine  + DocumentExtensions.BeautifyXml(xmlDocument);

            MessageBox.Show(detalleError, " Id :" + ruleException.Id + " - " + ruleException.TypeActivity, MessageBoxButtons.OK, MessageBoxIcon.Information);                  
        }


    }
}
