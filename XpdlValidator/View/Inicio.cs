﻿using System;
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
            fileReader.Title = "Por favor selecciona una arhico XPDL para validarlo.";
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
                    txtWelcomeMessage.Text = "Bienvenidos a XPDL VALIDATOR, pulsa el botón 'Buscar archivo' para selecionar un archivo .XPDL y despues pulsa 'Cargar archivo .XPDL' para validarlo.";
                    txtWelcomeMessage.BackColor = Color.WhiteSmoke;

                    frmConfiguracion.ShowDialog();
                    Show();
                }

            }
            catch (Exception ex)
            {
                txtWelcomeMessage.Text = "Error al cargar el archivo .XPDL, detalle error : " + ex.Message;
                txtWelcomeMessage.BackColor = Color.FromArgb(255, 192, 192);
            }
        }

    }
}
