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
    public partial class FrmCargar : Form
    {
        Serializador<Duenio> dueniosJson = null;
        Serializador<Mascota> mascotasXml = null;
        FrmDuenio frmDuenio;
        DialogResult resultado;

        public FrmCargar()
        {
            InitializeComponent();
        }

        public FrmCargar(Serializador<Duenio> dueniosJson, Serializador<Mascota> mascotasXml) : this()
        {
            this.dueniosJson = dueniosJson;
            this.mascotasXml = mascotasXml;
        }

        public Duenio GetDuenioElegido()
        {
            return (Duenio)this.lbListaDuenios.SelectedItem;
        }

        /// <summary>
        /// Carga la lista de duenios en el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCargarDuenio_Load(object sender, EventArgs e)
        {
            CargarListbox();
        }

        /// <summary>
        /// Vuelve al formulario anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Devuelve OK y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Si se cambia el texto se busca un match de lo que ingreso el usuario con la lista de duenios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.txtBuscarNombre.Text))
            {
                this.lbListaDuenios.DataSource = this.dueniosJson.Lista;
            }
            else
            {
                this.lbListaDuenios.DataSource = null;
                this.lbListaDuenios.Items.Clear();

                foreach (Duenio item in this.dueniosJson.Lista)
                {
                    string itemAux = item.Nombre.ToLower();

                    if (itemAux.StartsWith(this.txtBuscarNombre.Text.ToLower()))
                    {
                        this.lbListaDuenios.Items.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Borrar duenio de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Duenio aux = (Duenio)this.lbListaDuenios.SelectedItem;
                resultado = MessageBox.Show($"¿Esta seguro que desea eliminar a {aux.Nombre}?", "Alerta!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    this.dueniosJson.Eliminar(aux);
                    EliminarMascotas(aux);
                    CargarListbox();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No se seleccionó ningun Dueño");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Abrir otro form para modificar el duenio seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Duenio aux = (Duenio)this.lbListaDuenios.SelectedItem;
                frmDuenio = new FrmDuenio(this.dueniosJson, aux);
                frmDuenio.ShowDialog();
                CargarListbox();
            }
            catch (Exception)
            {
                MessageBox.Show("No se seleccionó ningun Dueño");
                Close();
            }
        }

        /// <summary>
        /// Carga la lista de duenios en el ListBox
        /// </summary>
        void CargarListbox()
        {
            this.lbListaDuenios.DataSource = null;
            this.lbListaDuenios.Items.Clear();
            this.lbListaDuenios.DataSource = this.dueniosJson.Lista;
        }

        /// <summary>
        /// Elimina mascotas de la lista Serializador
        /// </summary>
        /// <param name="aux"></param>
        void EliminarMascotas(Duenio aux)
        {
            foreach (int id in aux.IdMascotas)
            {
                foreach (Mascota item in this.mascotasXml.Lista)
                {
                    if (item.Id == id)
                    {
                        this.mascotasXml.Eliminar(item);
                        break;
                    }
                }
            }
        }
    }
}
