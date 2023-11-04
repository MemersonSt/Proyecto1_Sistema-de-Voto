namespace Proyecto1_Sistema_de_Voto {
    partial class formInicio {
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnVotosTotal = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIniciarVoto = new System.Windows.Forms.Button();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.panelContenedor.Controls.Add(this.label1);
            this.panelContenedor.Controls.Add(this.btnVotosTotal);
            this.panelContenedor.Controls.Add(this.btnSalir);
            this.panelContenedor.Controls.Add(this.btnIniciarVoto);
            this.panelContenedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.panelContenedor.Location = new System.Drawing.Point(-1, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1184, 661);
            this.panelContenedor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(873, 63);
            this.label1.TabIndex = 11;
            this.label1.Text = "Bienvenido al proceso de votación";
            // 
            // btnVotosTotal
            // 
            this.btnVotosTotal.BackgroundImage = global::Proyecto1_Sistema_de_Voto.Properties.Resources.grafico_histograma;
            this.btnVotosTotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVotosTotal.FlatAppearance.BorderSize = 0;
            this.btnVotosTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVotosTotal.Location = new System.Drawing.Point(1135, 12);
            this.btnVotosTotal.Name = "btnVotosTotal";
            this.btnVotosTotal.Size = new System.Drawing.Size(37, 35);
            this.btnVotosTotal.TabIndex = 10;
            this.btnVotosTotal.UseVisualStyleBackColor = true;
            this.btnVotosTotal.Click += new System.EventHandler(this.btnVotosTotal_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = global::Proyecto1_Sistema_de_Voto.Properties.Resources.cerrar_sesion;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalir.Location = new System.Drawing.Point(1122, 599);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(50, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIniciarVoto
            // 
            this.btnIniciarVoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.btnIniciarVoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarVoto.Font = new System.Drawing.Font("Cambria", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarVoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.btnIniciarVoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIniciarVoto.Location = new System.Drawing.Point(383, 346);
            this.btnIniciarVoto.Name = "btnIniciarVoto";
            this.btnIniciarVoto.Size = new System.Drawing.Size(413, 70);
            this.btnIniciarVoto.TabIndex = 7;
            this.btnIniciarVoto.Text = "Iniciar";
            this.btnIniciarVoto.UseVisualStyleBackColor = false;
            this.btnIniciarVoto.Click += new System.EventHandler(this.btnIniciarVoto_Click);
            // 
            // formInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Voto";
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIniciarVoto;
        private System.Windows.Forms.Button btnVotosTotal;
        private System.Windows.Forms.Label label1;
    }
}

