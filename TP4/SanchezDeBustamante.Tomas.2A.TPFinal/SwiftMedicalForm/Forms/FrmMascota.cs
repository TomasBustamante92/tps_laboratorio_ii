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
    public partial class FrmMascota : Form
    {
        Mascota mascota = null;
        Mascota animalAux = null;
        int idDuenio;
        bool MascotaModificada;
        int ultimoId;
        int id;
        DialogResult resultado;

        DelegadoCargarMascotaEnLista delegadoCargarMascotaEnLista;

        public FrmMascota()
        {
            InitializeComponent();
        }

        public FrmMascota(DelegadoCargarMascotaEnLista delegadoCargarMascotaEnLista,
            int idDuenio, int ultimoId) : this()
        {
            this.delegadoCargarMascotaEnLista = delegadoCargarMascotaEnLista;
            this.idDuenio = idDuenio;
            this.ultimoId = ultimoId;
            MascotaModificada = false;
        }

        public FrmMascota(Serializador<Mascota> mascotaSql, Mascota m) : this()
        {
            this.mascota = m;
            this.animalAux = new Mascota(m.Id, m.Tipo, m.Nombre, m.Edad, m.Raza, m.IdDuenio, m.Activo);
            this.id = m.Id;
            MascotaModificada = true;
            CargarMascota();
        }

        public int UltimoId
        {
            get { return this.ultimoId; }
        }

        public Mascota Mascota
        {
            get { return this.mascota; }
        }

        /// <summary>
        /// Si se escribió algo se pregunta si esta de acuerdo en volver al form anterior, 
        /// si no escribió nada se cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (this.MascotaModificada == false &&
                (!string.IsNullOrWhiteSpace(this.txtEdad.Text) ||
                 !string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                 !string.IsNullOrWhiteSpace(this.txtRaza.Text)))
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
        /// Carga los datos ingresados en el form a una mascota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            int edad;
            bool numeroParseable = int.TryParse(txtEdad.Text, out edad);

            if (!string.IsNullOrWhiteSpace(this.txtEdad.Text) &&
                !string.IsNullOrWhiteSpace(this.txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(this.txtRaza.Text) && numeroParseable && edad > 0)
            {
                if(MascotaModificada)
                {
                    ModificarMascota(this.animalAux, edad); 

                    resultado = MessageBox.Show(this.animalAux.ToString(), "¿Está seguro de realizar estos cambios?",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        ModificarMascota(this.mascota, edad); 
                        Close();
                    }
                    else if (resultado == DialogResult.No)
                    {
                        Close();
                    }
                }
                else
                {
                    AgregarMascotaALista(edad);
                }
            }
            else
            {
                MessageBox.Show(MensajeCampoVacio(numeroParseable,edad));
            }
        }

        /// <summary>
        /// Carga las opciones del ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAnimal_Load(object sender, EventArgs e)
        {
            this.cmbTipoAnimal.Items.Add(TipoAnimal.Gato);
            this.cmbTipoAnimal.Items.Add(TipoAnimal.Perro);
            this.cmbTipoAnimal.Items.Add(TipoAnimal.Ñandú);

            if(!MascotaModificada)
            {
                this.cmbTipoAnimal.SelectedItem = TipoAnimal.Gato;
            }
            else
            {
                this.cmbTipoAnimal.SelectedItem = this.Mascota.Tipo;
            }
        }

        /// <summary>
        /// Evalua si alguno de los campos a completar está vacio y si lo están devuelve un mensaje
        /// </summary>
        /// <param name="numeroParseable"></param>
        /// <returns></returns>
        string MensajeCampoVacio(bool numeroParseable, int edad)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                sb.AppendLine("El campo de Nombre esta vacio");
            }

            if (string.IsNullOrWhiteSpace(this.txtEdad.Text))
            {
                sb.AppendLine("El campo de Edad esta vacio");
            }
            else if (!numeroParseable)
            {
                sb.AppendLine("El campo de Edad esta incorrecto");
            }

            if (edad < 0)
            {
                sb.AppendLine("La edad no puede ser negativa");
            }

            if (string.IsNullOrWhiteSpace(this.txtRaza.Text))
            {
                sb.AppendLine("El campo de Raza esta vacio");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Intenta agregar la mascota a la lista Serializador, si no puede aparece un mensaje en pantalla
        /// </summary>
        /// <param name="edad"></param>
        void AgregarMascotaALista(int edad)
        {
            TipoAnimal tipoAux = (TipoAnimal)this.cmbTipoAnimal.SelectedItem;
            this.ultimoId++;
            this.mascota = new Mascota(this.ultimoId, tipoAux, txtNombre.Text, edad, txtRaza.Text, this.idDuenio, true);
            this.delegadoCargarMascotaEnLista.Invoke(this.mascota);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Carga los datos de la mascota a modificar
        /// </summary>
        void CargarMascota()
        {
            this.lblNuevaMascota.Text = "Modificar Mascota";
            this.txtNombre.Text = this.Mascota.Nombre;
            this.txtEdad.Text = this.Mascota.Edad.ToString();
            this.txtRaza.Text = this.Mascota.Raza;
        }

        /// <summary>
        /// Modifica el objeto mascota con lo ingresado por el usuario
        /// </summary>
        /// <param name="m"></param>
        /// <param name="edad"></param>
        void ModificarMascota(Mascota m, int edad)
        {
            m.Nombre = this.txtNombre.Text;
            m.Edad = edad;
            m.Tipo = (TipoAnimal)this.cmbTipoAnimal.SelectedItem;
            m.Raza = this.txtRaza.Text;
        }
    }
}
