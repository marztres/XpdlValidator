namespace XpdlValidator.View
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtWelcomeMessage = new System.Windows.Forms.TextBox();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRutaArchivo.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaArchivo.Location = new System.Drawing.Point(193, 302);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(542, 33);
            this.txtRutaArchivo.TabIndex = 9;
            this.txtRutaArchivo.TextChanged += new System.EventHandler(this.txtRutaArchivo_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Open Sans Extrabold", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(-4, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(989, 79);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "XPDL VALIDATOR V. 1.0";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWelcomeMessage
            // 
            this.txtWelcomeMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWelcomeMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWelcomeMessage.Font = new System.Drawing.Font("Open Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWelcomeMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtWelcomeMessage.HideSelection = false;
            this.txtWelcomeMessage.Location = new System.Drawing.Point(81, 99);
            this.txtWelcomeMessage.Multiline = true;
            this.txtWelcomeMessage.Name = "txtWelcomeMessage";
            this.txtWelcomeMessage.ReadOnly = true;
            this.txtWelcomeMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWelcomeMessage.Size = new System.Drawing.Size(820, 173);
            this.txtWelcomeMessage.TabIndex = 12;
            this.txtWelcomeMessage.TabStop = false;
            this.txtWelcomeMessage.Text = "Bienvenidos a XPDL VALIDATOR, pulsa el botón \'Buscar archivo\' para selecionar un " +
    "archivo .XPDL y despues pulsa \'Cargar archivo .XPDL\' para validarlo.\r\n\r\n";
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargarArchivo.Enabled = false;
            this.btnCargarArchivo.Font = new System.Drawing.Font("Open Sans", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCargarArchivo.Location = new System.Drawing.Point(220, 361);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(515, 75);
            this.btnCargarArchivo.TabIndex = 13;
            this.btnCargarArchivo.Text = "Cargar archivo .XPDL";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.cargarArchivo);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarArchivo.Font = new System.Drawing.Font("Open Sans", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscarArchivo.Location = new System.Drawing.Point(750, 293);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(151, 48);
            this.btnBuscarArchivo.TabIndex = 14;
            this.btnBuscarArchivo.Text = "Search";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.buscarArchivo);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 508);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.txtWelcomeMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtRutaArchivo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XPDL VALIDATOR V. 1.0 By @marztres - Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtWelcomeMessage;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Button btnBuscarArchivo;
    }
}