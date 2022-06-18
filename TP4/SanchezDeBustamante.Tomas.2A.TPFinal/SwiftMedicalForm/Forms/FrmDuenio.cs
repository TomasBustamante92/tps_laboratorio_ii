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
        //Serializador<Duenio> dueniosJson = null;
        Serializador<Duenio> dueniosSql = null;

        Duenio duenioAux = null;

        Duenio duenio = null;
        bool duenioModificado;
        int id;
        DialogResult resultado;

        public FrmDuenio()
        {
            InitializeComponent();
        }

        //public FrmDuenio(Serializador<Duenio> dueniosJson, int ultimoId) : this()
        //{
        //    this.dueniosJson = dueniosJson;
        //    this.id = ultimoId + 1;
        //    this.duenioModificado = false;
        //}

        //public FrmDuenio(Serializador<Duenio> dueniosJson) : this()
        //{
        //    this.dueniosJson = dueniosJson;
        //    this.duenioModificado = false;
        //}

        public FrmDuenio(Serializador<Duenio> dueniosSql, int ultimoId) : this()
        {
            this.dueniosSql = dueniosSql;
            this.id = ultimoId + 1;
            this.duenioModificado = false;
        }

        public FrmDuenio(Serializador<Duenio> duenios, Duenio d) : this()
        {
            //this.duenioSql = new Duenio(d.Id, d.Nombre, d.Telefono, d.Direccion, d.IdMascotas);
            this.duenioAux = new Duenio(d.Id, d.Nombre, d.Telefono, d.Direccion, d.Activo);

            this.duenio = d;
            this.id = duenio.Id;
            this.duenioModificado = true;
            this.dueniosSql = duenios;
            CargarDuenioForm();
        }

        public Duenio GetDuenio
        {
            get { return this.duenio; }
        }

        /// <summary>
        /// Si se escribió algo se pregunta si esta de acuerdo en volver al form anterior, 
        /// si no escribió nada se cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (this.duenioModificado == false &&
                (!string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(this.txtTelefono.Text) ||
                !string.IsNullOrWhiteSpace(this.txtDireccion.Text)))
            {
                resultado = MessageBox.Show("Si vuelve atras se borrarán los datos", "Alerta!",
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

        /// <summary>
        /// Carga los datos ingresados en el form a un dueño
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    resultado = MessageBox.Show(this.duenioAux.ToString(), "¿Está seguro de realizar estos cambios?",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        ModificarDuenio(this.duenio, telefono);
                        Close();
                    }
                    else if (resultado == DialogResult.No)
                    {
                        Close();
                    }
                }
                else
                {
                    //this.duenio = new Duenio(this.id, this.txtNombre.Text, telefono, this.txtDireccion.Text);
                    this.duenio = new Duenio(this.id, this.txtNombre.Text, telefono, this.txtDireccion.Text, true);
                    AgregarDuenioALista(this.duenio);
                }
            }
            else
            {
                MessageBox.Show(MensajeCampoVacio(this.txtNombre.Text, this.txtTelefono.Text,
                    this.txtDireccion.Text, telefonoEsNumero));
            }
        }

        /// <summary>
        /// Intenta agregar el duenio a la lista Serializador, si no puede aparece un mensaje en pantalla
        /// </summary>
        /// <param name="d">Duenio a agregar</param>
        void AgregarDuenioALista(Duenio d)
        {
            if (this.dueniosSql.Agregar(d))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Dueño ya está en la base de datos!");
            }
        }

        /// <summary>
        /// Carga el objeto Duenio con los datos ingresados
        /// </summary>
        /// <param name="d"></param>
        /// <param name="telefono"></param>
        void ModificarDuenio(Duenio d, int telefono)
        {
            d.Nombre = this.txtNombre.Text;
            d.Telefono = telefono;
            d.Direccion = this.txtDireccion.Text;
        }

        /// <summary>
        /// Evalua si alguno de los campos a completar está vacio y si lo están devuelve un mensaje
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="telefonoEsNumero"></param>
        /// <returns>mensaje de alerta</returns>
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

        /// <summary>
        /// Carga los datos del duenio a modificar
        /// </summary>
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
