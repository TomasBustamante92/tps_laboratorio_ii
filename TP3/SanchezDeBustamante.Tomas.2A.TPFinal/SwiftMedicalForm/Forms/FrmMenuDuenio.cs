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
    public partial class FrmMenuDuenio : Form
    {
        const string PATH = "..\\..\\..\\Archivos";
        Serializador<Animal> animalesXml = null;
        Serializador<Duenio> dueniosJson = null;
        Duenio duenio = null;
        List<Animal> animales;
        StringBuilder historial;
        int ultimoIdAnimal;

        public FrmMenuDuenio()
        {
            InitializeComponent();
            animalesXml = new Serializador<Animal>();
            dueniosJson = new Serializador<Duenio>();
            animales = new List<Animal>();
            historial = new StringBuilder();
        }

        public FrmMenuDuenio(Serializador<Duenio> dueniosJson, Duenio d, int ultimoIdAnimal) : this()
        {
            this.dueniosJson = dueniosJson;
            this.duenio = d;
            this.ultimoIdAnimal = ultimoIdAnimal;
        }

        public int UltimoId
        {
            get { return this.ultimoIdAnimal; }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            GuardarArchivoXml();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            // Se crea nuevo animal
            FrmAnimal animal = new FrmAnimal(this.animalesXml, this.ultimoIdAnimal);

            if(animal.ShowDialog() == DialogResult.OK)
            {
                // Lo agregamos a la lista XML

                this.animalesXml.Agregar(animal.Mascota);

                // AGREGAR IDS ANIMALES REVISAAAAR
                this.duenio.IdAnimales = AgregarId(this.duenio.IdAnimales, animal.Mascota.ID); 
                // actualizar id
                this.ultimoIdAnimal = animal.UltimoId;

                // Carga a lista local
                CargarListaAnimales();
                CargarForm();
                SeleccionarAnimalRecienCreado();
            }
            else
            {
                MessageBox.Show("No Pasaron cosas");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            GuardarArchivoXml();
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            FrmHistorial historial = new FrmHistorial();

            if(this.cmbMascota.SelectedItem is not null)
            {
                int indice = this.IndiceAnimal(this.cmbMascota.SelectedItem.ToString());

                try
                {
                    if (historial.ShowDialog() == DialogResult.OK)
                    {
                        CargarHistorial(historial.Historial, animales[indice]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Error! No se pudo encontrar a la mascota!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una mascota");
            }
            
        }

        private void FrmMenuDuenio_Load(object sender, EventArgs e)
        {
            this.lblDatoNombre.Text = string.Empty;
            this.lblDatoEdad.Text = string.Empty;
            this.lblDatoRaza.Text = string.Empty;
            this.lblDatoTipo.Text = string.Empty;
            this.lblNombreDuenio.Text = this.duenio.Nombre;
            this.lblDatoDireccion.Text = this.duenio.Direccion;
            this.lblDatoTelefono.Text = this.duenio.Telefono.ToString();

            CargarArchivoXml();
            CargarListaAnimales();
            CargarForm();
            SeleccionarPrimeraOpcionPorDefault();
        }

        void CargarForm()
        {
            ActualizarHistorial();
            CargarMascotasEnComboBox();
        }

        int IndiceAnimal(string s)
        {
            for(int i=0; i<this.animales.Count; i++)
            {
                if(this.animales[i].ToString() == s)
                {
                    return i;
                }
            }
            throw new IndexOutOfRangeException();
        }

        void CargarHistorial(string h, Animal a)
        {
            this.historial.Clear();
            this.historial.Append(a.Historial);
            this.historial.Insert(0, "------------------------------------ \n\n");
            this.historial.Insert(0, h + "\n\n");
            this.historial.Insert(0, $"Fecha: {DateTime.Now.ToShortDateString().ToString()} \n\n");
            a.Historial = historial.ToString();
            this.rtbHistorial.Text = a.Historial;
        }

        bool ActualizarHistorial()
        {
            if (this.cmbMascota.SelectedItem is not null)
            {
                int indice = IndiceAnimal(this.cmbMascota.SelectedItem.ToString());

                try
                {
                    this.rtbHistorial.Text = this.animales[indice].Historial;
                    return true;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Error! No se pudo encontrar a la mascota!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return false;
        }

        private void cmbMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = this.IndiceAnimal(this.cmbMascota.SelectedItem.ToString());
            this.rtbHistorial.Text = animales[indice].Historial;
            this.lblDatoNombre.Text = animales[indice].Nombre;
            this.lblDatoEdad.Text = animales[indice].Edad.ToString();
            this.lblDatoRaza.Text = animales[indice].Raza;
            this.lblDatoTipo.Text = animales[indice].Tipo.ToString();
        }

        int[] AgregarId(int[] listaAAgregar, int id)
        {
            List<int> ids = new List<int>();

            if(listaAAgregar is not null)
            {
                foreach (int item in listaAAgregar)
                {
                    ids.Add(item);
                }
            }
            ids.Add(id);

            return ids.ToArray();
        }

        void GuardarArchivoXml()
        {
            try
            {
                this.animalesXml.GuardarListaXml(PATH, "Animales");
            }
            catch
            {
                MessageBox.Show("No se pudo guardar el archivo Animales");
            }
        }

        void CargarArchivoXml()
        {
            try
            {
                this.animalesXml.CargarListaXml(PATH, "Animales");
            }
            catch
            {
                MessageBox.Show("No se pudo cargar el archivo Animales");
            }
        }

        void CargarListaAnimales()
        {
            this.animales.Clear(); // revisar cuando se borre o modifiquen animales
            try
            {
                foreach (Animal item in this.animalesXml.Lista)
                {
                    foreach (int idAnimal in this.duenio.IdAnimales)
                    {
                        if (idAnimal == item.ID)
                        {
                            this.animales.Add(item);
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("La lista de mascotas está vacia");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void CargarMascotasEnComboBox()
        {
            this.cmbMascota.Items.Clear();

            foreach (Animal item in this.animales)
            {
                this.cmbMascota.Items.Add(item.ToString());
            }
        }

        void SeleccionarPrimeraOpcionPorDefault()
        {
            if (this.animales.Count != 0)
            {
                this.cmbMascota.SelectedItem = this.cmbMascota.Items[0];
            }
        }

        void SeleccionarAnimalRecienCreado()
        {
            this.cmbMascota.SelectedItem = this.cmbMascota.Items[this.animales.Count - 1];
        }
    }
}
