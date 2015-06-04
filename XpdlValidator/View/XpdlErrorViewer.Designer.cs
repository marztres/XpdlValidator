namespace XpdlValidator.View
{
    partial class XpdlErrorViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtXmlViewer = new System.Windows.Forms.RichTextBox();
            this.lblVisorErrores = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblListadoErrores = new System.Windows.Forms.Label();
            this.gvErrores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtXmlViewer
            // 
            this.txtXmlViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXmlViewer.Location = new System.Drawing.Point(2, 81);
            this.txtXmlViewer.Name = "txtXmlViewer";
            this.txtXmlViewer.ReadOnly = true;
            this.txtXmlViewer.Size = new System.Drawing.Size(952, 235);
            this.txtXmlViewer.TabIndex = 1;
            this.txtXmlViewer.Text = "";
            // 
            // lblVisorErrores
            // 
            this.lblVisorErrores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVisorErrores.Font = new System.Drawing.Font("Open Sans Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisorErrores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVisorErrores.Location = new System.Drawing.Point(2, -2);
            this.lblVisorErrores.Name = "lblVisorErrores";
            this.lblVisorErrores.Size = new System.Drawing.Size(952, 37);
            this.lblVisorErrores.TabIndex = 4;
            this.lblVisorErrores.Text = "VISOR DE ERRORES";
            this.lblVisorErrores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Open Sans Light", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(2, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(952, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Archivo .XPDL cargado :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblListadoErrores
            // 
            this.lblListadoErrores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListadoErrores.Font = new System.Drawing.Font("Open Sans Light", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoErrores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblListadoErrores.Location = new System.Drawing.Point(2, 319);
            this.lblListadoErrores.Name = "lblListadoErrores";
            this.lblListadoErrores.Size = new System.Drawing.Size(952, 30);
            this.lblListadoErrores.TabIndex = 10001;
            this.lblListadoErrores.Text = "Listado de errores : ";
            this.lblListadoErrores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gvErrores
            // 
            this.gvErrores.AllowUserToAddRows = false;
            this.gvErrores.AllowUserToDeleteRows = false;
            this.gvErrores.AllowUserToResizeColumns = false;
            this.gvErrores.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gvErrores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvErrores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gvErrores.BackgroundColor = System.Drawing.Color.White;
            this.gvErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvErrores.CausesValidation = false;
            this.gvErrores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gvErrores.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.gvErrores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvErrores.ColumnHeadersHeight = 34;
            this.gvErrores.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvErrores.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvErrores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvErrores.EnableHeadersVisualStyles = false;
            this.gvErrores.GridColor = System.Drawing.Color.Black;
            this.gvErrores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvErrores.Location = new System.Drawing.Point(2, 349);
            this.gvErrores.Margin = new System.Windows.Forms.Padding(6);
            this.gvErrores.MultiSelect = false;
            this.gvErrores.Name = "gvErrores";
            this.gvErrores.ReadOnly = true;
            this.gvErrores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvErrores.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvErrores.RowHeadersVisible = false;
            this.gvErrores.RowHeadersWidth = 60;
            this.gvErrores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gvErrores.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvErrores.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gvErrores.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvErrores.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.gvErrores.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.gvErrores.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvErrores.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvErrores.ShowCellErrors = false;
            this.gvErrores.ShowCellToolTips = false;
            this.gvErrores.ShowEditingIcon = false;
            this.gvErrores.ShowRowErrors = false;
            this.gvErrores.Size = new System.Drawing.Size(952, 186);
            this.gvErrores.TabIndex = 10004;
            this.gvErrores.Paint += new System.Windows.Forms.PaintEventHandler(this.gvErrores_Paint);
            // 
            // XpdlErrorViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 533);
            this.Controls.Add(this.gvErrores);
            this.Controls.Add(this.lblListadoErrores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVisorErrores);
            this.Controls.Add(this.txtXmlViewer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XpdlErrorViewer";
            this.Text = "XPDL VALIDATOR V. 1.0 By @marztres - Visor de errores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XpdlErrorViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtXmlViewer;
        private System.Windows.Forms.Label lblVisorErrores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblListadoErrores;
        private System.Windows.Forms.DataGridView gvErrores;
    }
}