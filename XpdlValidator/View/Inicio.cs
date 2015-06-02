using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace XpdlValidator.View
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void buscarArchivo(object sender, EventArgs e)
        {
            OpenFileDialog fileReader = new OpenFileDialog();

            fileReader.Filter = "Image files (*.xpdl) | *.xpdl;";
            fileReader.Title = "Por favor selecciona una arhico XPDL para validarlo.";
            if (fileReader.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = fileReader.FileName;
            }
        }

        private void txtRutaArchivo_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRutaArchivo.Text))
            {
                btnCargarArchivo.Enabled = false;
            }
            else
            {
                btnCargarArchivo.Enabled = true;
            }
        }

        private void cargarArchivo(object sender, EventArgs e)
        {
            string rutaXmlDocument = txtRutaArchivo.Text;

            if (File.Exists(rutaXmlDocument))
            {
                try
                {
                    XDocument xmlXDocument = XDocument.Load(rutaXmlDocument);

                    using (XpdlErrorViewer frmConfiguracion = new XpdlErrorViewer(xmlXDocument))
                    {
                        frmConfiguracion.ShowDialog();
                        Show();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar archivo XPDL detalle : " + ex.Message);
                }
            }
        }
    }
}
