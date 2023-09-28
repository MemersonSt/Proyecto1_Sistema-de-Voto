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
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxProvincia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtCedula
            // 
            resources.ApplyResources(this.txtCedula, "txtCedula");
            this.txtCedula.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCedula.Name = "txtCedula";
            // 
            // txtNombres
            // 
            resources.ApplyResources(this.txtNombres, "txtNombres");
            this.txtNombres.Name = "txtNombres";
            // 
            // txtApellidos
            // 
            resources.ApplyResources(this.txtApellidos, "txtApellidos");
            this.txtApellidos.Name = "txtApellidos";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            resources.ApplyResources(this.btnContinuar, "btnContinuar");
            this.btnContinuar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cboxProvincia
            // 
            resources.ApplyResources(this.cboxProvincia, "cboxProvincia");
            this.cboxProvincia.FormattingEnabled = true;
            this.cboxProvincia.Items.AddRange(new object[] {
            resources.GetString("cboxProvincia.Items"),
            resources.GetString("cboxProvincia.Items1"),
            resources.GetString("cboxProvincia.Items2"),
            resources.GetString("cboxProvincia.Items3"),
            resources.GetString("cboxProvincia.Items4"),
            resources.GetString("cboxProvincia.Items5"),
            resources.GetString("cboxProvincia.Items6"),
            resources.GetString("cboxProvincia.Items7"),
            resources.GetString("cboxProvincia.Items8"),
            resources.GetString("cboxProvincia.Items9"),
            resources.GetString("cboxProvincia.Items10"),
            resources.GetString("cboxProvincia.Items11"),
            resources.GetString("cboxProvincia.Items12"),
            resources.GetString("cboxProvincia.Items13"),
            resources.GetString("cboxProvincia.Items14"),
            resources.GetString("cboxProvincia.Items15"),
            resources.GetString("cboxProvincia.Items16"),
            resources.GetString("cboxProvincia.Items17"),
            resources.GetString("cboxProvincia.Items18"),
            resources.GetString("cboxProvincia.Items19"),
            resources.GetString("cboxProvincia.Items20"),
            resources.GetString("cboxProvincia.Items21"),
            resources.GetString("cboxProvincia.Items22"),
            resources.GetString("cboxProvincia.Items23")});
            this.cboxProvincia.Name = "cboxProvincia";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtContraseña
            // 
            resources.ApplyResources(this.txtContraseña, "txtContraseña");
            this.txtContraseña.Name = "txtContraseña";
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
            // DatosDelVotante
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cboxProvincia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DatosDelVotante";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxProvincia;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnVolver;
    }
}