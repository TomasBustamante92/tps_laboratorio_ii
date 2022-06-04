
namespace SwiftMedicalForm
{
    partial class frmModificarOpciones
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
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnModificarDuenio = new System.Windows.Forms.Button();
            this.btnModificarMascota = new System.Windows.Forms.Button();
            this.lblModificar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAtras.Location = new System.Drawing.Point(270, 91);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(78, 29);
            this.btnAtras.TabIndex = 17;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnModificarDuenio
            // 
            this.btnModificarDuenio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificarDuenio.Location = new System.Drawing.Point(30, 39);
            this.btnModificarDuenio.Name = "btnModificarDuenio";
            this.btnModificarDuenio.Size = new System.Drawing.Size(147, 45);
            this.btnModificarDuenio.TabIndex = 18;
            this.btnModificarDuenio.Text = "Dueño";
            this.btnModificarDuenio.UseVisualStyleBackColor = true;
            this.btnModificarDuenio.Click += new System.EventHandler(this.btnModificarDuenio_Click);
            // 
            // btnModificarMascota
            // 
            this.btnModificarMascota.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificarMascota.Location = new System.Drawing.Point(183, 39);
            this.btnModificarMascota.Name = "btnModificarMascota";
            this.btnModificarMascota.Size = new System.Drawing.Size(147, 45);
            this.btnModificarMascota.TabIndex = 19;
            this.btnModificarMascota.Text = "Mascota";
            this.btnModificarMascota.UseVisualStyleBackColor = true;
            this.btnModificarMascota.Click += new System.EventHandler(this.btnModificarMascota_Click);
            // 
            // lblModificar
            // 
            this.lblModificar.AutoSize = true;
            this.lblModificar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblModificar.Location = new System.Drawing.Point(12, 9);
            this.lblModificar.Name = "lblModificar";
            this.lblModificar.Size = new System.Drawing.Size(89, 21);
            this.lblModificar.TabIndex = 34;
            this.lblModificar.Text = "Modificar:";
            // 
            // frmModificarOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 132);
            this.Controls.Add(this.lblModificar);
            this.Controls.Add(this.btnModificarMascota);
            this.Controls.Add(this.btnModificarDuenio);
            this.Controls.Add(this.btnAtras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmModificarOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModificarOpciones";
            this.Load += new System.EventHandler(this.frmModificarOpciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnModificarDuenio;
        private System.Windows.Forms.Button btnModificarMascota;
        private System.Windows.Forms.Label lblModificar;
    }
}