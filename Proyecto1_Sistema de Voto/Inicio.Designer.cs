﻿namespace Proyecto1_Sistema_de_Voto {
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
            this.btnIniciarVoto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.panelContenedor.Controls.Add(this.label1);
            this.panelContenedor.Controls.Add(this.button1);
            this.panelContenedor.Controls.Add(this.button3);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(707, 54);
            this.label1.TabIndex = 11;
            this.label1.Text = "Bienvenido al proceso Electoral";
            // 
            // btnIniciarVoto
            // 
            this.btnIniciarVoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(114)))), ((int)(((byte)(175)))));
            this.btnIniciarVoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarVoto.Font = new System.Drawing.Font("Palatino Linotype", 30F);
            this.btnIniciarVoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.btnIniciarVoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIniciarVoto.Location = new System.Drawing.Point(384, 346);
            this.btnIniciarVoto.Name = "btnIniciarVoto";
            this.btnIniciarVoto.Size = new System.Drawing.Size(413, 70);
            this.btnIniciarVoto.TabIndex = 7;
            this.btnIniciarVoto.Text = "Iniciar";
            this.btnIniciarVoto.UseVisualStyleBackColor = false;
            this.btnIniciarVoto.Click += new System.EventHandler(this.btnIniciarVoto_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Proyecto1_Sistema_de_Voto.Properties.Resources.grafico_histograma;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1135, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 35);
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
            // formInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelContenedor);
            this.Name = "formInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Voto";
            this.Load += new System.EventHandler(this.formInicio_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnIniciarVoto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

