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
    public partial class FrmAnimal : Form
    {
        Serializador<Animal> animalXml = null;
        Animal animal = null;
        int ultimoId;

        public FrmAnimal()
        {
            InitializeComponent();
        }

        public FrmAnimal(Serializador<Animal> animalXml, int ultimoId) : this()
        {
            this.animalXml = animalXml;
            this.ultimoId = ultimoId;
        }

        public int UltimoId
        {
            get { return this.ultimoId; }
        }

        public Animal Mascota
        {
            get { return this.animal; }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            int edad;
            bool numeroParseable = int.TryParse(txtEdad.Text, out edad);

            if(!string.IsNullOrWhiteSpace(this.txtEdad.Text) &&
                !string.IsNullOrWhiteSpace(this.txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(this.txtRaza.Text) && numeroParseable)
            {
                Animal.TipoAnimal tipoAux = (Animal.TipoAnimal)this.cmbTipoAnimal.SelectedItem;

                this.ultimoId += 1;
                this.animal = new Animal(this.ultimoId, tipoAux, txtNombre.Text, edad, txtRaza.Text);

                if (this.animalXml.Agregar(this.animal))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar al animal");
                }
            }
            else
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
                else if(!numeroParseable)
                {
                    sb.AppendLine("El campo de Edad esta incorrecto");
                }

                if (string.IsNullOrWhiteSpace(this.txtRaza.Text))
                {
                    sb.AppendLine("El campo de Raza esta vacio");
                }

                MessageBox.Show(sb.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmAnimal_Load(object sender, EventArgs e)
        {
            this.cmbTipoAnimal.Items.Add(Animal.TipoAnimal.Gato);
            this.cmbTipoAnimal.Items.Add(Animal.TipoAnimal.Perro);
            this.cmbTipoAnimal.Items.Add(Animal.TipoAnimal.Ñandú);
            this.cmbTipoAnimal.SelectedItem = Animal.TipoAnimal.Gato;
        }
    }
}
