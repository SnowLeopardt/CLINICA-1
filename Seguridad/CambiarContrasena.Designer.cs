﻿
namespace CLINICA_1
{
    partial class CambiarContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContrasena));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.txtNueva = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña Actual:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(252, 140);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(206, 36);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtActual
            // 
            this.txtActual.Location = new System.Drawing.Point(252, 203);
            this.txtActual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtActual.Multiline = true;
            this.txtActual.Name = "txtActual";
            this.txtActual.PasswordChar = '*';
            this.txtActual.Size = new System.Drawing.Size(206, 36);
            this.txtActual.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirmar Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 278);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nueva Contraseña:";
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Location = new System.Drawing.Point(252, 332);
            this.txtConfirmar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmar.Multiline = true;
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.PasswordChar = '*';
            this.txtConfirmar.Size = new System.Drawing.Size(206, 36);
            this.txtConfirmar.TabIndex = 7;
            // 
            // txtNueva
            // 
            this.txtNueva.Location = new System.Drawing.Point(252, 271);
            this.txtNueva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNueva.Multiline = true;
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.PasswordChar = '*';
            this.txtNueva.Size = new System.Drawing.Size(206, 36);
            this.txtNueva.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "CAMBIAR CONTRASEÑA";
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.Blue;
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.Location = new System.Drawing.Point(216, 417);
            this.btnCambiar.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(202, 55);
            this.btnCambiar.TabIndex = 36;
            this.btnCambiar.Text = "CAMBIAR";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // CambiarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(640, 512);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.txtNueva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtActual);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CambiarContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLINICA VARGAS - CAMBIAR CONTRASEÑA";
            this.Load += new System.EventHandler(this.CambiarContrasena_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.TextBox txtNueva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCambiar;
    }
}