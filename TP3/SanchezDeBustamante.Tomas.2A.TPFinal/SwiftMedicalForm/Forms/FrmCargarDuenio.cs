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
    public partial class FrmCargarDuenio : Form
    {
        Serializador<Duenio> duenios = null;

        public FrmCargarDuenio()
        {
            InitializeComponent();
        }

        public FrmCargarDuenio(Serializador<Duenio> duenios) : this()
        {
            this.duenios = duenios;
        }

        public Duenio GetDuenioElegido()
        {
            return (Duenio)this.lbListaDuenios.SelectedItem;
        }

        private void FrmCargarDuenio_Load(object sender, EventArgs e)
        {
            CargarListbox();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.txtBuscarNombre.Text))
            {
                this.lbListaDuenios.DataSource = this.duenios.Lista;
            }
            else
            {
                this.lbListaDuenios.DataSource = null;
                this.lbListaDuenios.Items.Clear();

                foreach (Duenio item in this.duenios.Lista)
                {
                    string itemAux = item.Nombre.ToLower();

                    if (itemAux.StartsWith(this.txtBuscarNombre.Text.ToLower()))
                    {
                        this.lbListaDuenios.Items.Add(item);
                    }
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Duenio aux = (Duenio)this.lbListaDuenios.SelectedItem;
            DialogResult resultado = MessageBox.Show($"¿Esta seguro que desea eliminar a {aux.Nombre}?", "Alerta!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                this.duenios.Eliminar(aux);
                CargarListbox();
            }
        }

        void CargarListbox()
        {
            this.lbListaDuenios.DataSource = null;
            this.lbListaDuenios.Items.Clear();
            this.lbListaDuenios.DataSource = this.duenios.Lista;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Duenio aux = (Duenio)this.lbListaDuenios.SelectedItem;

            FrmNuevo modificarDuenio = new FrmNuevo(this.duenios, aux);
            modificarDuenio.ShowDialog();
            CargarListbox();
        }
    }
}
