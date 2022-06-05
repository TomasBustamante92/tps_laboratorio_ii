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
    public partial class FrmDuenio : Form
    {
        Serializador<Duenio> dueniosJson = null;
        Duenio duenioAux = null;
        Duenio duenio = null;
        bool duenioModificado;
        int id;

        public FrmDuenio()
        {
            InitializeComponent();
        }

        public FrmDuenio(Serializador<Duenio> dueniosJson, int ultimoId) : this()
        {
            this.dueniosJson = dueniosJson;
            this.id = ultimoId + 1;
            this.duenioModificado = false;
        }

        public FrmDuenio(Serializador<Duenio> duenios, Duenio d) : this()
        {
            this.duenioAux = new Duenio(d.Id, d.Nombre, d.Telefono, d.Direccion, d.IdMascotas);
            this.duenio = d;
            this.id = duenio.Id;
            this.duenioModificado = true;
            this.dueniosJson = duenios;
            CargarDuenioForm();
        }

        public Duenio GetDuenio
        {
            get { return this.duenio; }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (this.duenioModificado == false &&
                (!string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(this.txtTelefono.Text) ||
                !string.IsNullOrWhiteSpace(this.txtDireccion.Text)))
            {
                DialogResult resultado = MessageBox.Show("Si vuelve atras se borrarán los datos", "Alerta!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            int telefono;
            bool telefonoEsNumero = int.TryParse(txtTelefono.Text, out telefono);

            if (!string.IsNullOrWhiteSpace(this.txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(this.txtTelefono.Text) &&
                telefonoEsNumero && !string.IsNullOrWhiteSpace(this.txtDireccion.Text))
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
                MessageBox.Show(MensajeCampoVacio(this.txtNombre.Text, this.txtTelefono.Text,
                    this.txtDireccion.Text, telefonoEsNumero));
            }
        }

        void AgregarDuenioBaseDeDatos(int telefono)
        {
            this.duenio = new Duenio(this.id, this.txtNombre.Text, telefono, this.txtDireccion.Text);

            if (this.dueniosJson.Agregar(duenio))
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

        string MensajeCampoVacio(string nombre, string telefono, string direccion, bool telefonoEsNumero)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                sb.AppendLine("El campo de Nombre esta vacio");
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                sb.AppendLine("El campo de Telefono esta vacio");
            }
            else if (!telefonoEsNumero)
            {
                sb.AppendLine("El campo de Telefono esta incorrecto");
            }

            if (string.IsNullOrWhiteSpace(direccion))
            {
                sb.AppendLine("El campo de Dirección esta vacio");
            }

            return sb.ToString();
        }

        void CargarDuenioForm()
        {
            this.lblNuevoDuenio.Text = "Modificar Dueño";
            this.lblConfirmar.Text = "Modificar";
            this.txtNombre.Text = duenio.Nombre;
            this.txtTelefono.Text = duenio.Telefono.ToString();
            this.txtDireccion.Text = duenio.Direccion;
        }
    }
}
