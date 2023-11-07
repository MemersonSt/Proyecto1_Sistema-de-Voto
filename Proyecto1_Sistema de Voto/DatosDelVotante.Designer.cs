namespace Proyecto1_Sistema_de_Voto {
    partial class DatosDelVotante {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatosDelVotante));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textCedula = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxProvincia = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label3.Name = "label3";
            // 
            // textCedula
            // 
            resources.ApplyResources(this.textCedula, "textCedula");
            this.textCedula.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textCedula.Name = "textCedula";
            // 
            // textNombre
            // 
            resources.ApplyResources(this.textNombre, "textNombre");
            this.textNombre.Name = "textNombre";
            // 
            // textApellido
            // 
            resources.ApplyResources(this.textApellido, "textApellido");
            this.textApellido.Name = "textApellido";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label4.Name = "label4";
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            resources.ApplyResources(this.btnContinuar, "btnContinuar");
            this.btnContinuar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label5.Name = "label5";
            // 
            // cboxProvincia
            // 
            resources.ApplyResources(this.cboxProvincia, "cboxProvincia");
            this.cboxProvincia.FormattingEnabled = true;
            this.cboxProvincia.Items.AddRange(new object[] {
            resources.GetString("cboxProvincia.Items"),
            resources.GetString("cboxProvincia.Items1"),
            resources.GetString("cboxProvincia.Items2")});
            this.cboxProvincia.Name = "cboxProvincia";
            // 
            // btnVolver
            // 
            this.btnVolver.BackgroundImage = global::Proyecto1_Sistema_de_Voto.Properties.Resources.cerrar_sesion;
            resources.ApplyResources(this.btnVolver, "btnVolver");
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label6.Name = "label6";
            // 
            // textPassword
            // 
            resources.ApplyResources(this.textPassword, "textPassword");
            this.textPassword.Name = "textPassword";
            // 
            // cbSexo
            // 
            resources.ApplyResources(this.cbSexo, "cbSexo");
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Items.AddRange(new object[] {
            resources.GetString("cbSexo.Items"),
            resources.GetString("cbSexo.Items1"),
            resources.GetString("cbSexo.Items2")});
            this.cbSexo.Name = "cbSexo";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label7.Name = "label7";
            // 
            // DatosDelVotante
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.Controls.Add(this.cbSexo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cboxProvincia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textApellido);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textCedula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DatosDelVotante";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxProvincia;
        private System.Windows.Forms.TextBox textCedula;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.Label label7;
    }
}