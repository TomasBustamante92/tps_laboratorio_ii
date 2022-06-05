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

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (this.MascotaModificada == false &&
                (!string.IsNullOrWhiteSpace(this.txtEdad.Text) ||
                 !string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                 !string.IsNullOrWhiteSpace(this.txtRaza.Text)))
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
            int edad;
            bool numeroParseable = int.TryParse(txtEdad.Text, out edad);

            if (!string.IsNullOrWhiteSpace(this.txtEdad.Text) &&
                !string.IsNullOrWhiteSpace(this.txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(this.txtRaza.Text) && numeroParseable)
            {
                if(MascotaModificada)
                {
                    ModificarMascota(this.animalAux, edad);

                    DialogResult result = MessageBox.Show(this.animalAux.ToString(), "¿Está seguro de realizar estos cambios?",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ModificarMascota(this.mascota, edad);
                        Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Close();
                    }
                }
                else
                {
                    AgregarMascotaABaseDeDatos(edad);
                }
            }
            else
            {
                MessageBox.Show(MensajeCampoVacio(numeroParseable));
            }
        }

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

        void AgregarMascotaABaseDeDatos(int edad)
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

        private void FrmAnimal_Load(object sender, EventArgs e)
        {
            this.cmbTipoAnimal.Items.Add(Mascota.TipoAnimal.Gato);
            this.cmbTipoAnimal.Items.Add(Mascota.TipoAnimal.Perro);
            this.cmbTipoAnimal.Items.Add(Mascota.TipoAnimal.Ñandú);
            this.cmbTipoAnimal.SelectedItem = Mascota.TipoAnimal.Gato;
        }

        void CargarMascota()
        {
            this.lblNuevaMascota.Text = "Modificar Mascota";
            this.cmbTipoAnimal.SelectedItem = this.Mascota.Tipo;
            this.txtNombre.Text = this.Mascota.Nombre;
            this.txtEdad.Text = this.Mascota.Edad.ToString();
            this.txtRaza.Text = this.Mascota.Raza;
        }

        void ModificarMascota(Mascota a, int edad)
        {
            a.Nombre = this.txtNombre.Text;
            a.Edad = edad;
            a.Tipo = (Mascota.TipoAnimal)this.cmbTipoAnimal.SelectedItem;
            a.Raza = this.txtRaza.Text;
        }
    }
}
