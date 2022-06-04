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
        Duenio duenioAux = null;
        Duenio duenio = null;
        bool duenioModificado;
        int id;

        public FrmNuevo()
        {
            InitializeComponent();
        }

        public FrmNuevo(Serializador<Duenio> duenios, int ultimoId) : this()
        {
            this.duenios = duenios;
            this.id = ultimoId + 1;
            this.duenioModificado = false;
        }

        public FrmNuevo(Serializador<Duenio> duenios, Duenio d) : this()
        {
            this.duenioAux = new Duenio(d.ID, d.Nombre, d.Telefono, d.Direccion, d.IdAnimales);
            this.duenio = d;
            this.id = duenio.ID;
            this.duenioModificado = true;
            this.duenios = duenios;
            CargarDuenio();
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
                if(duenioModificado)
                {
                    ModificarDuenio(this.duenioAux, telefono);

                    DialogResult result = MessageBox.Show(this.duenioAux.ToString(), "¿Está seguro de realizar estos cambios?",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ModificarDuenio(this.duenio, telefono);
                        Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Close();
                    }
                }
                else
                {
                    AgregarDuenioBaseDeDatos(telefono);
                }
            }
            else
            {
                MessageBox.Show(MensajeCampoVacio(numeroParseable));
            }
        }

        void AgregarDuenioBaseDeDatos(int telefono)
        {
            this.duenio = new Duenio(this.id, this.txtNombre.Text, telefono, this.txtDireccion.Text);
            if (this.duenios.Agregar(duenio))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Dueño ya está en la base de datos!");
            }
        }

        void ModificarDuenio(Duenio d, int telefono)
        {
            d.Nombre = this.txtNombre.Text;
            d.Telefono = telefono;
            d.Direccion = this.txtDireccion.Text;
        }

        string MensajeCampoVacio(bool numeroParseable)
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

            return sb.ToString();
        }

        void CargarDuenio()
        {
            this.lblNuevoDuenio.Text = "Modificar Dueño";
            this.lblConfirmar.Text = "Modificar";
            this.txtNombre.Text = duenio.Nombre;
            this.txtTelefono.Text = duenio.Telefono.ToString();
            this.txtDireccion.Text = duenio.Direccion;
        }
    }
}
