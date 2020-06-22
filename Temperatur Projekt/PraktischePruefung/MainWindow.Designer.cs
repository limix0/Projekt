namespace PraktischePruefung
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.grpBxServerRaum = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVolt = new System.Windows.Forms.Label();
            this.lblCOMPort = new System.Windows.Forms.Label();
            this.cmBxCOMPorts = new System.Windows.Forms.ComboBox();
            this.SevSegDis_1 = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.btnStartMessung = new System.Windows.Forms.Button();
            this.grpBxServerRaum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBxServerRaum
            // 
            this.grpBxServerRaum.Controls.Add(this.SevSegDis_1);
            this.grpBxServerRaum.Controls.Add(this.cmBxCOMPorts);
            this.grpBxServerRaum.Controls.Add(this.lblCOMPort);
            this.grpBxServerRaum.Controls.Add(this.lblVolt);
            this.grpBxServerRaum.Location = new System.Drawing.Point(12, 111);
            this.grpBxServerRaum.Name = "grpBxServerRaum";
            this.grpBxServerRaum.Size = new System.Drawing.Size(409, 153);
            this.grpBxServerRaum.TabIndex = 1;
            this.grpBxServerRaum.TabStop = false;
            this.grpBxServerRaum.Text = "Temperatur";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(91, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblVolt
            // 
            this.lblVolt.AutoSize = true;
            this.lblVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolt.Location = new System.Drawing.Point(299, 20);
            this.lblVolt.Name = "lblVolt";
            this.lblVolt.Size = new System.Drawing.Size(101, 73);
            this.lblVolt.TabIndex = 0;
            this.lblVolt.Text = "°V";
            // 
            // lblCOMPort
            // 
            this.lblCOMPort.AutoSize = true;
            this.lblCOMPort.Location = new System.Drawing.Point(315, 99);
            this.lblCOMPort.Name = "lblCOMPort";
            this.lblCOMPort.Size = new System.Drawing.Size(53, 13);
            this.lblCOMPort.TabIndex = 1;
            this.lblCOMPort.Text = "COM Port";
            // 
            // cmBxCOMPorts
            // 
            this.cmBxCOMPorts.FormattingEnabled = true;
            this.cmBxCOMPorts.Location = new System.Drawing.Point(312, 115);
            this.cmBxCOMPorts.Name = "cmBxCOMPorts";
            this.cmBxCOMPorts.Size = new System.Drawing.Size(66, 21);
            this.cmBxCOMPorts.TabIndex = 2;
            this.cmBxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.cmBxCOMPorts_SelectedIndexChanged);
            // 
            // SevSegDis_1
            // 
            this.SevSegDis_1.ArrayCount = 3;
            this.SevSegDis_1.ColorBackground = System.Drawing.Color.DimGray;
            this.SevSegDis_1.ColorDark = System.Drawing.Color.Transparent;
            this.SevSegDis_1.ColorLight = System.Drawing.Color.Chartreuse;
            this.SevSegDis_1.DecimalShow = true;
            this.SevSegDis_1.ElementPadding = new System.Windows.Forms.Padding(4, 4, 15, 4);
            this.SevSegDis_1.ElementWidth = 10;
            this.SevSegDis_1.ItalicFactor = 0F;
            this.SevSegDis_1.Location = new System.Drawing.Point(28, 19);
            this.SevSegDis_1.Name = "SevSegDis_1";
            this.SevSegDis_1.Size = new System.Drawing.Size(265, 122);
            this.SevSegDis_1.TabIndex = 5;
            this.SevSegDis_1.TabStop = false;
            this.SevSegDis_1.Value = "5.12";
            // 
            // btnStartMessung
            // 
            this.btnStartMessung.Location = new System.Drawing.Point(13, 271);
            this.btnStartMessung.Name = "btnStartMessung";
            this.btnStartMessung.Size = new System.Drawing.Size(408, 39);
            this.btnStartMessung.TabIndex = 4;
            this.btnStartMessung.Text = "Messung starten";
            this.btnStartMessung.UseVisualStyleBackColor = true;
            this.btnStartMessung.Click += new System.EventHandler(this.btnStartMessung_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(435, 322);
            this.Controls.Add(this.btnStartMessung);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpBxServerRaum);
            this.Name = "MainWindow";
            this.Text = "Temperatur";
            this.grpBxServerRaum.ResumeLayout(false);
            this.grpBxServerRaum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBxServerRaum;
        private DmitryBrant.CustomControls.SevenSegmentArray SevSegDis_1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmBxCOMPorts;
        private System.Windows.Forms.Label lblCOMPort;
        private System.Windows.Forms.Label lblVolt;
        private System.Windows.Forms.Button btnStartMessung;
    }
}

