namespace Proyecto1_Sistema_de_Voto {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent () {
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.btnIniciarVoto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.panelContenedor.Controls.Add(this.button1);
            this.panelContenedor.Controls.Add(this.button3);
            this.panelContenedor.Controls.Add(this.btnAdministrador);
            this.panelContenedor.Controls.Add(this.btnIniciarVoto);
            this.panelContenedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.panelContenedor.Location = new System.Drawing.Point(-1, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1184, 661);
            this.panelContenedor.TabIndex = 0;
            // 
            // btnIniciarVoto
            // 
            this.btnIniciarVoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(114)))), ((int)(((byte)(175)))));
            this.btnIniciarVoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarVoto.Font = new System.Drawing.Font("Palatino Linotype", 20.25F);
            this.btnIniciarVoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.btnIniciarVoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIniciarVoto.Location = new System.Drawing.Point(361, 288);
            this.btnIniciarVoto.Name = "btnIniciarVoto";
            this.btnIniciarVoto.Size = new System.Drawing.Size(488, 81);
            this.btnIniciarVoto.TabIndex = 7;
            this.btnIniciarVoto.Text = "Iniciar el Proceso de Votación";
            this.btnIniciarVoto.UseVisualStyleBackColor = false;
            this.btnIniciarVoto.Click += new System.EventHandler(this.btnIniciarVoto_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Proyecto1_Sistema_de_Voto.Properties.Resources.grafico_histograma;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1114, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 58);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Proyecto1_Sistema_de_Voto.Properties.Resources.cerrar_sesion;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(1122, 599);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.BackgroundImage = global::Proyecto1_Sistema_de_Voto.Properties.Resources.admin;
            this.btnAdministrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdministrador.FlatAppearance.BorderSize = 0;
            this.btnAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAdministrador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdministrador.Location = new System.Drawing.Point(1113, 12);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(60, 60);
            this.btnAdministrador.TabIndex = 8;
            this.btnAdministrador.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelContenedor);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Voto";
            this.panelContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Button btnIniciarVoto;
        private System.Windows.Forms.Button button1;
    }
}

