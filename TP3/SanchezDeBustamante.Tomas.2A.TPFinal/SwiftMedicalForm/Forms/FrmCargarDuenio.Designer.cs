
namespace SwiftMedicalForm
{
    partial class FrmCargarDuenio
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
            this.lbListaDuenios = new System.Windows.Forms.ListBox();
            this.lblCargarDuenio = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblConfirmar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbListaDuenios
            // 
            this.lbListaDuenios.FormattingEnabled = true;
            this.lbListaDuenios.ItemHeight = 15;
            this.lbListaDuenios.Location = new System.Drawing.Point(12, 199);
            this.lbListaDuenios.Name = "lbListaDuenios";
            this.lbListaDuenios.Size = new System.Drawing.Size(801, 259);
            this.lbListaDuenios.TabIndex = 0;
            // 
            // lblCargarDuenio
            // 
            this.lblCargarDuenio.AutoSize = true;
            this.lblCargarDuenio.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCargarDuenio.Location = new System.Drawing.Point(320, 50);
            this.lblCargarDuenio.Name = "lblCargarDuenio";
            this.lblCargarDuenio.Size = new System.Drawing.Size(182, 37);
            this.lblCargarDuenio.TabIndex = 1;
            this.lblCargarDuenio.Text = "Cargar Dueño";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(319, 150);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.PlaceholderText = "Nombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(230, 23);
            this.txtBuscarNombre.TabIndex = 9;
            this.txtBuscarNombre.TextChanged += new System.EventHandler(this.txtBuscarNombre_TextChanged);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAtras.Location = new System.Drawing.Point(662, 537);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(151, 44);
            this.btnAtras.TabIndex = 11;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmar.Location = new System.Drawing.Point(338, 464);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(151, 44);
            this.lblConfirmar.TabIndex = 10;
            this.lblConfirmar.Text = "Confirmar";
            this.lblConfirmar.UseVisualStyleBackColor = true;
            this.lblConfirmar.Click += new System.EventHandler(this.lblConfirmar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(786, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(27, 28);
            this.btnSalir.TabIndex = 45;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBuscar.Location = new System.Drawing.Point(236, 150);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(77, 25);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar:";
            // 
            // FrmCargarDuenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(825, 593);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblConfirmar);
            this.Controls.Add(this.txtBuscarNombre);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblCargarDuenio);
            this.Controls.Add(this.lbListaDuenios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCargarDuenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCargarDuenio";
            this.Load += new System.EventHandler(this.FrmCargarDuenio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbListaDuenios;
        private System.Windows.Forms.Label lblCargarDuenio;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button lblConfirmar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblBuscar;
    }
}