
namespace SwiftMedicalForm
{
    partial class FrmMascota
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
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblConfirmar = new System.Windows.Forms.Button();
            this.lblRaza = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblNombreDuenio = new System.Windows.Forms.Label();
            this.lblNuevaMascota = new System.Windows.Forms.Label();
            this.cmbTipoAnimal = new System.Windows.Forms.ComboBox();
            this.lblTipoDeAnimal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(363, 383);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(168, 23);
            this.txtRaza.TabIndex = 19;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(363, 316);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(168, 23);
            this.txtEdad.TabIndex = 18;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(363, 248);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(168, 23);
            this.txtNombre.TabIndex = 17;
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAtras.Location = new System.Drawing.Point(662, 537);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(151, 44);
            this.btnAtras.TabIndex = 16;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmar.Location = new System.Drawing.Point(337, 465);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(151, 44);
            this.lblConfirmar.TabIndex = 15;
            this.lblConfirmar.Text = "Confirmar";
            this.lblConfirmar.UseVisualStyleBackColor = true;
            this.lblConfirmar.Click += new System.EventHandler(this.lblConfirmar_Click);
            // 
            // lblRaza
            // 
            this.lblRaza.AutoSize = true;
            this.lblRaza.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRaza.Location = new System.Drawing.Point(299, 383);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(58, 25);
            this.lblRaza.TabIndex = 14;
            this.lblRaza.Text = "Raza:";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEdad.Location = new System.Drawing.Point(297, 316);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(61, 25);
            this.lblEdad.TabIndex = 13;
            this.lblEdad.Text = "Edad:";
            // 
            // lblNombreDuenio
            // 
            this.lblNombreDuenio.AutoSize = true;
            this.lblNombreDuenio.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreDuenio.Location = new System.Drawing.Point(267, 247);
            this.lblNombreDuenio.Name = "lblNombreDuenio";
            this.lblNombreDuenio.Size = new System.Drawing.Size(91, 25);
            this.lblNombreDuenio.TabIndex = 12;
            this.lblNombreDuenio.Text = "Nombre:";
            // 
            // lblNuevaMascota
            // 
            this.lblNuevaMascota.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNuevaMascota.Location = new System.Drawing.Point(239, 65);
            this.lblNuevaMascota.Name = "lblNuevaMascota";
            this.lblNuevaMascota.Size = new System.Drawing.Size(347, 37);
            this.lblNuevaMascota.TabIndex = 11;
            this.lblNuevaMascota.Text = "Nueva Mascota";
            this.lblNuevaMascota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTipoAnimal
            // 
            this.cmbTipoAnimal.FormattingEnabled = true;
            this.cmbTipoAnimal.Location = new System.Drawing.Point(363, 180);
            this.cmbTipoAnimal.Name = "cmbTipoAnimal";
            this.cmbTipoAnimal.Size = new System.Drawing.Size(168, 23);
            this.cmbTipoAnimal.TabIndex = 20;
            // 
            // lblTipoDeAnimal
            // 
            this.lblTipoDeAnimal.AutoSize = true;
            this.lblTipoDeAnimal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoDeAnimal.Location = new System.Drawing.Point(298, 180);
            this.lblTipoDeAnimal.Name = "lblTipoDeAnimal";
            this.lblTipoDeAnimal.Size = new System.Drawing.Size(57, 25);
            this.lblTipoDeAnimal.TabIndex = 21;
            this.lblTipoDeAnimal.Text = "Tipo:";
            // 
            // FrmMascota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(825, 593);
            this.Controls.Add(this.lblTipoDeAnimal);
            this.Controls.Add(this.cmbTipoAnimal);
            this.Controls.Add(this.txtRaza);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblConfirmar);
            this.Controls.Add(this.lblRaza);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblNombreDuenio);
            this.Controls.Add(this.lblNuevaMascota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMascota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAnimal";
            this.Load += new System.EventHandler(this.FrmAnimal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button lblConfirmar;
        private System.Windows.Forms.Label lblRaza;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblNombreDuenio;
        private System.Windows.Forms.Label lblNuevaMascota;
        private System.Windows.Forms.ComboBox cmbTipoAnimal;
        private System.Windows.Forms.Label lblTipoDeAnimal;
    }
}