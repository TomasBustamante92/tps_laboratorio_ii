
namespace SwiftMedicalForm
{
    partial class FrmIngreso
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngreso));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblVeterinaria = new System.Windows.Forms.Label();
            this.btnMusica = new System.Windows.Forms.Button();
            this.imgSonido = new System.Windows.Forms.ImageList(this.components);
            this.lblAviso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SwiftMedicalForm.Properties.Resources.H3xGWiol_400x400;
            this.pictureBox1.Location = new System.Drawing.Point(200, -90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(424, 431);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNuevo.Location = new System.Drawing.Point(337, 265);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(151, 44);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCargar.Location = new System.Drawing.Point(337, 370);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(151, 44);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(337, 478);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(151, 44);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblVeterinaria
            // 
            this.lblVeterinaria.AutoSize = true;
            this.lblVeterinaria.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVeterinaria.Location = new System.Drawing.Point(362, 180);
            this.lblVeterinaria.Name = "lblVeterinaria";
            this.lblVeterinaria.Size = new System.Drawing.Size(101, 29);
            this.lblVeterinaria.TabIndex = 4;
            this.lblVeterinaria.Text = "Veterinaria";
            // 
            // btnMusica
            // 
            this.btnMusica.BackColor = System.Drawing.Color.Snow;
            this.btnMusica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMusica.FlatAppearance.BorderSize = 0;
            this.btnMusica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusica.ImageIndex = 0;
            this.btnMusica.ImageList = this.imgSonido;
            this.btnMusica.Location = new System.Drawing.Point(12, 12);
            this.btnMusica.Name = "btnMusica";
            this.btnMusica.Size = new System.Drawing.Size(41, 28);
            this.btnMusica.TabIndex = 6;
            this.btnMusica.UseVisualStyleBackColor = false;
            this.btnMusica.Click += new System.EventHandler(this.btnMusica_Click);
            // 
            // imgSonido
            // 
            this.imgSonido.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgSonido.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSonido.ImageStream")));
            this.imgSonido.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSonido.Images.SetKeyName(0, "sonido.png");
            this.imgSonido.Images.SetKeyName(1, "noSonido.png");
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(202, 569);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(422, 15);
            this.lblAviso.TabIndex = 7;
            this.lblAviso.Text = "Swift Medical Veterinaria™ - Dir: Calle Falsa 123 (Buenos Aires) - Tel: 4001-5842" +
    "  ";
            // 
            // FrmIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(825, 593);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnMusica);
            this.Controls.Add(this.lblVeterinaria);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIngreso";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIngreso_FormClosing);
            this.Load += new System.EventHandler(this.FrmIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblVeterinaria;
        private System.Windows.Forms.Button btnMusica;
        private System.Windows.Forms.ImageList imgSonido;
        private System.Windows.Forms.Label lblAviso;
    }
}

