
namespace CLINICA_1
{
    partial class ores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ores));
            this.txtExamenes = new System.Windows.Forms.TextBox();
            this.txtExameness = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtExamenes
            // 
            this.txtExamenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExamenes.Location = new System.Drawing.Point(0, 0);
            this.txtExamenes.Multiline = true;
            this.txtExamenes.Name = "txtExamenes";
            this.txtExamenes.ReadOnly = true;
            this.txtExamenes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExamenes.Size = new System.Drawing.Size(800, 450);
            this.txtExamenes.TabIndex = 0;
            // 
            // txtExameness
            // 
            this.txtExameness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExameness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExameness.Location = new System.Drawing.Point(0, 0);
            this.txtExameness.Multiline = true;
            this.txtExameness.Name = "txtExameness";
            this.txtExameness.ReadOnly = true;
            this.txtExameness.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExameness.Size = new System.Drawing.Size(415, 408);
            this.txtExameness.TabIndex = 0;
            // 
            // ores
            // 
            this.ClientSize = new System.Drawing.Size(415, 408);
            this.Controls.Add(this.txtExameness);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLINICA VARGAS - EXAMENES ANTERIORES ";
            this.Load += new System.EventHandler(this.FormExamenesAnteriores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExamenes;
        private System.Windows.Forms.TextBox txtExameness;
    }
}