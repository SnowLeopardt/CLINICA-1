using System;

namespace CLINICA_1
{
    partial class Registro
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
            
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.btneliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtresponsable = new System.Windows.Forms.TextBox();
            this.txtdireccion2 = new System.Windows.Forms.TextBox();
            this.txttelefono2 = new System.Windows.Forms.TextBox();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdui = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.botonAbrirCarpeta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.Red;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btneliminar.ForeColor = System.Drawing.Color.White;
            this.btneliminar.Location = new System.Drawing.Point(751, 428);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(120, 40);
            this.btneliminar.TabIndex = 24;
            this.btneliminar.Text = "ELIMINAR";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // txtresponsable
            // 
            this.txtresponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtresponsable.Location = new System.Drawing.Point(595, 148);
            this.txtresponsable.Name = "txtresponsable";
            this.txtresponsable.Size = new System.Drawing.Size(250, 24);
            this.txtresponsable.TabIndex = 47;
            // 
            // txtdireccion2
            // 
            this.txtdireccion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdireccion2.Location = new System.Drawing.Point(595, 197);
            this.txtdireccion2.Name = "txtdireccion2";
            this.txtdireccion2.Size = new System.Drawing.Size(250, 24);
            this.txtdireccion2.TabIndex = 46;
            // 
            // txttelefono2
            // 
            this.txttelefono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelefono2.Location = new System.Drawing.Point(595, 247);
            this.txttelefono2.Name = "txttelefono2";
            this.txttelefono2.Size = new System.Drawing.Size(250, 24);
            this.txttelefono2.TabIndex = 45;
            // 
            // txtcorreo
            // 
            this.txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcorreo.Location = new System.Drawing.Point(595, 294);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(250, 24);
            this.txtcorreo.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(488, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 43;
            this.label5.Text = "Responsable:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(507, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 42;
            this.label4.Text = "Direccion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(514, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 41;
            this.label3.Text = "Telefono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(444, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 21);
            this.label2.TabIndex = 40;
            this.label2.Text = "Correo Electronico:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "DUI:";
            // 
            // txtdui
            // 
            this.txtdui.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdui.Location = new System.Drawing.Point(132, 352);
            this.txtdui.Name = "txtdui";
            this.txtdui.Size = new System.Drawing.Size(250, 24);
            this.txtdui.TabIndex = 38;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(280, 44);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(333, 45);
            this.lblTitulo.TabIndex = 25;
            this.lblTitulo.Text = "DATOS PERSONALES";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(48, 141);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(77, 21);
            this.lblNombre.TabIndex = 26;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(132, 144);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 24);
            this.txtNombre.TabIndex = 27;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.ForeColor = System.Drawing.Color.White;
            this.lblEdad.Location = new System.Drawing.Point(72, 191);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(52, 21);
            this.lblEdad.TabIndex = 28;
            this.lblEdad.Text = "Edad:";
            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.Location = new System.Drawing.Point(132, 194);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(250, 24);
            this.txtEdad.TabIndex = 29;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.White;
            this.lblTelefono.Location = new System.Drawing.Point(48, 241);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(81, 21);
            this.lblTelefono.TabIndex = 30;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(132, 244);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(250, 24);
            this.txtTelefono.TabIndex = 31;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.White;
            this.lblDireccion.Location = new System.Drawing.Point(39, 293);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(87, 21);
            this.lblDireccion.TabIndex = 32;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(132, 294);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(250, 24);
            this.txtDireccion.TabIndex = 33;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(176)))), ((int)(((byte)(73)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(52, 428);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 40);
            this.btnNuevo.TabIndex = 34;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click_1);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Violet;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(232, 428);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 40);
            this.btnBuscar.TabIndex = 35;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(125)))), ((int)(((byte)(32)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(413, 428);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 40);
            this.btnEditar.TabIndex = 36;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(102)))), ((int)(((byte)(181)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(583, 428);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 40);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // botonAbrirCarpeta
            // 
            this.botonAbrirCarpeta.BackColor = System.Drawing.Color.Gold;
            this.botonAbrirCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAbrirCarpeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.botonAbrirCarpeta.ForeColor = System.Drawing.Color.Black;
            this.botonAbrirCarpeta.Location = new System.Drawing.Point(728, 44);
            this.botonAbrirCarpeta.Name = "botonAbrirCarpeta";
            this.botonAbrirCarpeta.Size = new System.Drawing.Size(134, 40);
            this.botonAbrirCarpeta.TabIndex = 49;
            this.botonAbrirCarpeta.Text = "BASE DE DATOS";
            this.botonAbrirCarpeta.UseVisualStyleBackColor = false;
            this.botonAbrirCarpeta.Click += new System.EventHandler(this.botonAbrirCarpeta_Click);
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(115)))));
            this.ClientSize = new System.Drawing.Size(883, 500);
            this.Controls.Add(this.botonAbrirCarpeta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtresponsable);
            this.Controls.Add(this.txtdireccion2);
            this.Controls.Add(this.txttelefono2);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdui);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btneliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLINICA VARGAS - REGISTRO DE DATOS";
            this.Load += new System.EventHandler(this.Registro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtresponsable;
        private System.Windows.Forms.TextBox txtdireccion2;
        private System.Windows.Forms.TextBox txttelefono2;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdui;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button botonAbrirCarpeta;
    }
}
