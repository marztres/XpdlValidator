using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XpdlValidator.View
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void BuscarArchivo(object sender, EventArgs e)
        {
            OpenFileDialog fileReader = new OpenFileDialog();

            fileReader.Filter = "Image files (*.xpdl) | *.xpdl;";
            fileReader.Title = " Please select a XPDL file to validate.";
            if (fileReader.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = fileReader.FileName;
            }
        }

        private void txtRutaArchivo_TextChanged(object sender, EventArgs e)
        {
            btnCargarArchivo.Enabled = !String.IsNullOrEmpty(txtRutaArchivo.Text);
        }

        private void CargarArchivo(object sender, EventArgs e)
        {
            string rutaXmlDocument = txtRutaArchivo.Text;

            if (!File.Exists(rutaXmlDocument)) return;
            try
            {
                XDocument xmlXDocument = XDocument.Load(rutaXmlDocument);

                using (XpdlErrorViewer frmConfiguracion = new XpdlErrorViewer(xmlXDocument))
                {
                    txtWelcomeMessage.Text = "Welcome to XPDL VALIDATOR, make click in 'Search' button and  select a XPDL file from your computer, them make click 'Load XPDL file' button to validate. ";
                    txtWelcomeMessage.BackColor = Color.WhiteSmoke;

                    frmConfiguracion.ShowDialog();
                    Show();
                }

            }
            catch (Exception ex)
            {
                txtWelcomeMessage.Text = "an error occurred please try again, Error detail : " + ex.Message;
                txtWelcomeMessage.BackColor = Color.FromArgb(255, 192, 192);
            }
        }

    }
}
