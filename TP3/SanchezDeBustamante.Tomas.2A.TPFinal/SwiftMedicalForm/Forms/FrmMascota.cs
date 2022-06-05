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
        Serializador<Mascota> mascotaXml = null;
        Mascota mascota = null;
        Mascota animalAux = null;
        bool MascotaModificada;
        int ultimoId;
        int id;
        DialogResult resultado;

        public FrmMascota()
        {
            InitializeComponent();
        }

        public FrmMascota(Serializador<Mascota> mascotaXml, int ultimoId) : this()
        {
            this.mascotaXml = mascotaXml;
            this.ultimoId = ultimoId;
            MascotaModificada = false;
        }

        public FrmMascota(Serializador<Mascota> mascotaXml, Mascota m) : this()
        {
            this.mascota = m;
            this.animalAux = new Mascota(m.Id, m.Tipo, m.Nombre, m.Edad, m.Raza);
            this.id = m.Id;
            this.mascotaXml = mascotaXml;
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
                !string.IsNullOrWhiteSpace(this.txtRaza.Text) && numeroParseable)
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
                MessageBox.Show(MensajeCampoVacio(numeroParseable));
            }
        }

        /// <summary>
        /// Carga las opciones del ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAnimal_Load(object sender, EventArgs e)
        {
            this.cmbTipoAnimal.Items.Add(Mascota.TipoAnimal.Gato);
            this.cmbTipoAnimal.Items.Add(Mascota.TipoAnimal.Perro);
            this.cmbTipoAnimal.Items.Add(Mascota.TipoAnimal.Ñandú);
            this.cmbTipoAnimal.SelectedItem = Mascota.TipoAnimal.Gato;
        }

        /// <summary>
        /// Evalua si alguno de los campos a completar está vacio y si lo están devuelve un mensaje
        /// </summary>
        /// <param name="numeroParseable"></param>
        /// <returns></returns>
        string MensajeCampoVacio(bool numeroParseable)
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
            Mascota.TipoAnimal tipoAux = (Mascota.TipoAnimal)this.cmbTipoAnimal.SelectedItem;
            this.ultimoId++;
            this.mascota = new Mascota(this.ultimoId, tipoAux, txtNombre.Text, edad, txtRaza.Text);

            if (this.mascotaXml.Agregar(this.mascota))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("La mascota ya está en la base de datos!");
            }
        }

        /// <summary>
        /// Carga los datos de la mascota a modificar
        /// </summary>
        void CargarMascota()
        {
            this.lblNuevaMascota.Text = "Modificar Mascota";
            this.cmbTipoAnimal.SelectedItem = this.Mascota.Tipo;
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
            m.Tipo = (Mascota.TipoAnimal)this.cmbTipoAnimal.SelectedItem;
            m.Raza = this.txtRaza.Text;
        }
    }
}
