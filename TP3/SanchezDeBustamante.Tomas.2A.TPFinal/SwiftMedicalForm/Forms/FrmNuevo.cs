using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace SwiftMedicalForm
{
    public partial class FrmNuevo : Form
    {
        Serializador<Duenio> duenios = null;
        Duenio duenio = null;
        int ultimoId;

        public FrmNuevo()
        {
            InitializeComponent();
        }

        public FrmNuevo(Serializador<Duenio> duenios, int ultimoId) : this()
        {
            this.duenios = duenios;
            this.ultimoId = ultimoId; 
        }

        public Duenio GetDuenio
        {
            get { return this.duenio; }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            int telefono;
            bool numeroParseable = int.TryParse(txtTelefono.Text, out telefono);

            if (!string.IsNullOrWhiteSpace(this.txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(this.txtTelefono.Text) &&
                numeroParseable && !string.IsNullOrWhiteSpace(this.txtDireccion.Text))
            {
                this.ultimoId += 1;
                this.duenio = new Duenio(this.ultimoId, this.txtNombre.Text, telefono, this.txtDireccion.Text);
                if(this.duenios.Agregar(duenio))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dueño ya está en la base de datos!");
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
                {
                    sb.AppendLine("El campo de Nombre esta vacio");
                }

                if (string.IsNullOrWhiteSpace(this.txtTelefono.Text))
                {
                    sb.AppendLine("El campo de Telefono esta vacio");
                }
                else if (!numeroParseable)
                {
                    sb.AppendLine("El campo de Telefono esta incorrecto");
                }

                if (string.IsNullOrWhiteSpace(this.txtDireccion.Text))
                {
                    sb.AppendLine("El campo de Dirección esta vacio");
                }

                MessageBox.Show(sb.ToString());
            }
        }
    }
}
