
namespace SwiftMedicalForm
{
    partial class FrmMenuPrincipal
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
            this.lblNombreDuenio = new System.Windows.Forms.Label();
            this.btnNuevaMascota = new System.Windows.Forms.Button();
            this.lblTipoDeAnimal = new System.Windows.Forms.Label();
            this.lblRaza = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblNombreMascota = new System.Windows.Forms.Label();
            this.lblMascota = new System.Windows.Forms.Label();
            this.cmbMascota = new System.Windows.Forms.ComboBox();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.btnNuevaEntrada = new System.Windows.Forms.Button();
            this.rtbHistorial = new System.Windows.Forms.RichTextBox();
            this.lblDatoTipo = new System.Windows.Forms.Label();
            this.lblDatoRaza = new System.Windows.Forms.Label();
            this.lblDatoEdad = new System.Windows.Forms.Label();
            this.lblDatoNombre = new System.Windows.Forms.Label();
            this.lblDatoTelefono = new System.Windows.Forms.Label();
            this.lblDatoDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.gbDuenio = new System.Windows.Forms.GroupBox();
            this.gbMascota = new System.Windows.Forms.GroupBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.gbDuenio.SuspendLayout();
            this.gbMascota.SuspendLayout();
            this.SuspendLayout();
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
            // lblNombreDuenio
            // 
            this.lblNombreDuenio.AutoEllipsis = true;
            this.lblNombreDuenio.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreDuenio.Location = new System.Drawing.Point(87, 63);
            this.lblNombreDuenio.Name = "lblNombreDuenio";
            this.lblNombreDuenio.Size = new System.Drawing.Size(650, 37);
            this.lblNombreDuenio.TabIndex = 11;
            this.lblNombreDuenio.Text = "Nombre Duenio";
            this.lblNombreDuenio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNuevaMascota
            // 
            this.btnNuevaMascota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNuevaMascota.Location = new System.Drawing.Point(518, 213);
            this.btnNuevaMascota.Name = "btnNuevaMascota";
            this.btnNuevaMascota.Size = new System.Drawing.Size(98, 24);
            this.btnNuevaMascota.TabIndex = 17;
            this.btnNuevaMascota.Text = "Nueva Mascota";
            this.btnNuevaMascota.UseVisualStyleBackColor = true;
            this.btnNuevaMascota.Click += new System.EventHandler(this.btnNuevaMascota_Click);
            // 
            // lblTipoDeAnimal
            // 
            this.lblTipoDeAnimal.AutoSize = true;
            this.lblTipoDeAnimal.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoDeAnimal.Location = new System.Drawing.Point(29, 29);
            this.lblTipoDeAnimal.Name = "lblTipoDeAnimal";
            this.lblTipoDeAnimal.Size = new System.Drawing.Size(135, 23);
            this.lblTipoDeAnimal.TabIndex = 25;
            this.lblTipoDeAnimal.Text = "Tipo de animal:";
            // 
            // lblRaza
            // 
            this.lblRaza.AutoSize = true;
            this.lblRaza.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRaza.Location = new System.Drawing.Point(432, 69);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(52, 23);
            this.lblRaza.TabIndex = 24;
            this.lblRaza.Text = "Raza:";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEdad.Location = new System.Drawing.Point(430, 30);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(55, 23);
            this.lblEdad.TabIndex = 23;
            this.lblEdad.Text = "Edad:";
            // 
            // lblNombreMascota
            // 
            this.lblNombreMascota.AutoSize = true;
            this.lblNombreMascota.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreMascota.Location = new System.Drawing.Point(30, 65);
            this.lblNombreMascota.Name = "lblNombreMascota";
            this.lblNombreMascota.Size = new System.Drawing.Size(81, 23);
            this.lblNombreMascota.TabIndex = 22;
            this.lblNombreMascota.Text = "Nombre:";
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMascota.Location = new System.Drawing.Point(61, 213);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(91, 25);
            this.lblMascota.TabIndex = 27;
            this.lblMascota.Text = "Mascota:";
            // 
            // cmbMascota
            // 
            this.cmbMascota.FormattingEnabled = true;
            this.cmbMascota.Location = new System.Drawing.Point(158, 214);
            this.cmbMascota.Name = "cmbMascota";
            this.cmbMascota.Size = new System.Drawing.Size(354, 23);
            this.cmbMascota.TabIndex = 26;
            this.cmbMascota.SelectedIndexChanged += new System.EventHandler(this.cmbMascota_SelectedIndexChanged);
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHistorial.Location = new System.Drawing.Point(305, 87);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(56, 17);
            this.lblHistorial.TabIndex = 29;
            this.lblHistorial.Text = "Historial";
            // 
            // btnNuevaEntrada
            // 
            this.btnNuevaEntrada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNuevaEntrada.Location = new System.Drawing.Point(267, 241);
            this.btnNuevaEntrada.Name = "btnNuevaEntrada";
            this.btnNuevaEntrada.Size = new System.Drawing.Size(132, 22);
            this.btnNuevaEntrada.TabIndex = 30;
            this.btnNuevaEntrada.Text = "Nueva Entrada";
            this.btnNuevaEntrada.UseVisualStyleBackColor = true;
            this.btnNuevaEntrada.Click += new System.EventHandler(this.btnNuevaEntrada_Click);
            // 
            // rtbHistorial
            // 
            this.rtbHistorial.Location = new System.Drawing.Point(32, 104);
            this.rtbHistorial.Name = "rtbHistorial";
            this.rtbHistorial.ReadOnly = true;
            this.rtbHistorial.Size = new System.Drawing.Size(603, 133);
            this.rtbHistorial.TabIndex = 32;
            this.rtbHistorial.Text = "";
            // 
            // lblDatoTipo
            // 
            this.lblDatoTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatoTipo.AutoEllipsis = true;
            this.lblDatoTipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatoTipo.Location = new System.Drawing.Point(163, 31);
            this.lblDatoTipo.Name = "lblDatoTipo";
            this.lblDatoTipo.Size = new System.Drawing.Size(261, 21);
            this.lblDatoTipo.TabIndex = 36;
            this.lblDatoTipo.Text = "tipo";
            this.lblDatoTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatoRaza
            // 
            this.lblDatoRaza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatoRaza.AutoEllipsis = true;
            this.lblDatoRaza.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatoRaza.Location = new System.Drawing.Point(484, 70);
            this.lblDatoRaza.Name = "lblDatoRaza";
            this.lblDatoRaza.Size = new System.Drawing.Size(174, 21);
            this.lblDatoRaza.TabIndex = 35;
            this.lblDatoRaza.Text = "raza";
            this.lblDatoRaza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatoEdad
            // 
            this.lblDatoEdad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatoEdad.AutoEllipsis = true;
            this.lblDatoEdad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatoEdad.Location = new System.Drawing.Point(484, 31);
            this.lblDatoEdad.Name = "lblDatoEdad";
            this.lblDatoEdad.Size = new System.Drawing.Size(174, 21);
            this.lblDatoEdad.TabIndex = 34;
            this.lblDatoEdad.Text = "edad";
            this.lblDatoEdad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatoNombre
            // 
            this.lblDatoNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatoNombre.AutoEllipsis = true;
            this.lblDatoNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatoNombre.Location = new System.Drawing.Point(110, 66);
            this.lblDatoNombre.Name = "lblDatoNombre";
            this.lblDatoNombre.Size = new System.Drawing.Size(314, 21);
            this.lblDatoNombre.TabIndex = 33;
            this.lblDatoNombre.Text = "nombre";
            this.lblDatoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatoTelefono
            // 
            this.lblDatoTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatoTelefono.AutoEllipsis = true;
            this.lblDatoTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatoTelefono.Location = new System.Drawing.Point(93, 26);
            this.lblDatoTelefono.Name = "lblDatoTelefono";
            this.lblDatoTelefono.Size = new System.Drawing.Size(268, 21);
            this.lblDatoTelefono.TabIndex = 40;
            this.lblDatoTelefono.Text = "teléfono";
            this.lblDatoTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatoDireccion
            // 
            this.lblDatoDireccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatoDireccion.AutoEllipsis = true;
            this.lblDatoDireccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatoDireccion.Location = new System.Drawing.Point(453, 25);
            this.lblDatoDireccion.Name = "lblDatoDireccion";
            this.lblDatoDireccion.Size = new System.Drawing.Size(205, 21);
            this.lblDatoDireccion.TabIndex = 39;
            this.lblDatoDireccion.Text = "Dirección";
            this.lblDatoDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTelefono.Location = new System.Drawing.Point(11, 25);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(83, 23);
            this.lblTelefono.TabIndex = 38;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDireccion.Location = new System.Drawing.Point(367, 24);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(90, 23);
            this.lblDireccion.TabIndex = 37;
            this.lblDireccion.Text = "Dirección:";
            // 
            // gbDuenio
            // 
            this.gbDuenio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbDuenio.Controls.Add(this.lblTelefono);
            this.gbDuenio.Controls.Add(this.lblDatoDireccion);
            this.gbDuenio.Controls.Add(this.lblDatoTelefono);
            this.gbDuenio.Controls.Add(this.lblDireccion);
            this.gbDuenio.Location = new System.Drawing.Point(79, 122);
            this.gbDuenio.Name = "gbDuenio";
            this.gbDuenio.Size = new System.Drawing.Size(667, 63);
            this.gbDuenio.TabIndex = 41;
            this.gbDuenio.TabStop = false;
            this.gbDuenio.Text = "Dueño";
            // 
            // gbMascota
            // 
            this.gbMascota.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMascota.Controls.Add(this.lblDatoEdad);
            this.gbMascota.Controls.Add(this.lblEdad);
            this.gbMascota.Controls.Add(this.rtbHistorial);
            this.gbMascota.Controls.Add(this.btnNuevaEntrada);
            this.gbMascota.Controls.Add(this.lblDatoRaza);
            this.gbMascota.Controls.Add(this.lblDatoNombre);
            this.gbMascota.Controls.Add(this.lblDatoTipo);
            this.gbMascota.Controls.Add(this.lblHistorial);
            this.gbMascota.Controls.Add(this.lblTipoDeAnimal);
            this.gbMascota.Controls.Add(this.lblNombreMascota);
            this.gbMascota.Controls.Add(this.lblRaza);
            this.gbMascota.Location = new System.Drawing.Point(79, 260);
            this.gbMascota.Name = "gbMascota";
            this.gbMascota.Size = new System.Drawing.Size(667, 271);
            this.gbMascota.TabIndex = 42;
            this.gbMascota.TabStop = false;
            this.gbMascota.Text = "Mascota";
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.Location = new System.Drawing.Point(12, 550);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(113, 31);
            this.btnExportar.TabIndex = 37;
            this.btnExportar.Text = "Exportar Mascota";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(622, 213);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(68, 24);
            this.btnModificar.TabIndex = 43;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBorrar.Location = new System.Drawing.Point(696, 213);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(68, 24);
            this.btnBorrar.TabIndex = 44;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(825, 593);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.gbMascota);
            this.Controls.Add(this.gbDuenio);
            this.Controls.Add(this.lblMascota);
            this.Controls.Add(this.cmbMascota);
            this.Controls.Add(this.btnNuevaMascota);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblNombreDuenio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenuDuenio";
            this.Load += new System.EventHandler(this.FrmMenuDuenio_Load);
            this.gbDuenio.ResumeLayout(false);
            this.gbDuenio.PerformLayout();
            this.gbMascota.ResumeLayout(false);
            this.gbMascota.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblNombreDuenio;
        private System.Windows.Forms.Button btnNuevaMascota;
        private System.Windows.Forms.Label lblTipoDeAnimal;
        private System.Windows.Forms.Label lblRaza;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblNombreMascota;
        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.ComboBox cmbMascota;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Button btnNuevaEntrada;
        private System.Windows.Forms.RichTextBox rtbHistorial;
        private System.Windows.Forms.Label lblDatoTipo;
        private System.Windows.Forms.Label lblDatoRaza;
        private System.Windows.Forms.Label lblDatoEdad;
        private System.Windows.Forms.Label lblDatoNombre;
        private System.Windows.Forms.Label lblDatoTelefono;
        private System.Windows.Forms.Label lblDatoDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.GroupBox gbDuenio;
        private System.Windows.Forms.GroupBox gbMascota;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
    }
}