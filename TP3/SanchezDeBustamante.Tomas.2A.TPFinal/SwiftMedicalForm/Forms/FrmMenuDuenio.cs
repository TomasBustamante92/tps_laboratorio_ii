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
        Duenio duenio = null;
        List<Animal> animales;
        StringBuilder historial;
        int ultimoIdAnimal;

        public FrmMenuDuenio()
        {
            InitializeComponent();
            animalesXml = new Serializador<Animal>();
            animales = new List<Animal>();
            historial = new StringBuilder();
        }

        public FrmMenuDuenio(Duenio d, int ultimoIdAnimal) : this()
        {
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
            FrmAnimal animal = new FrmAnimal(this.animalesXml, this.ultimoIdAnimal);

            if(animal.ShowDialog() == DialogResult.OK)
            {
                //this.animales.Add(animal.Mascota);
                this.animalesXml.Agregar(animal.Mascota);

                this.duenio.IdAnimales = ConvertirListaAArray(this.duenio.IdAnimales, animal.Mascota.ID); // AGREGAR IDS ANIMALES REVISAAAAR
                // actualizar id
                this.ultimoIdAnimal = animal.UltimoId;
                CargarListaAnimales();
                CargarForm();
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

            try
            {
                if(this.cmbMascota.SelectedItem is not null)
                {
                    int indice = this.IndiceAnimal(this.cmbMascota.SelectedItem.ToString());

                    if (indice != -1)
                    {
                        if (historial.ShowDialog() == DialogResult.OK)
                        {
                            //CargarHistorial(historial.Historial, animales[indice]);
                            CargarHistorial(historial.Historial, animalesXml.Lista[indice]);
                        }
                        else
                        {
                            MessageBox.Show("No Pasaron cosas");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Da -1 carnal");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una mascota");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        }

        void CargarForm()
        {
            this.cmbMascota.Items.Clear();

            foreach (Animal item in this.animales)
            {
                this.cmbMascota.Items.Add(item.ToString());
            }
        }

        int IndiceAnimal(string a)
        {
            for(int i=0; i<this.animales.Count; i++)
            {
                if(this.animales[i].ToString() == a)
                {
                    return i;
                }
            }
            return -1;
        }

        void CargarHistorial(string h, Animal a)
        {
            this.historial.Clear();
            this.historial.Append(a.Historial);
            this.historial.Insert(0, "------------------------------------ \n\n");
            this.historial.Insert(0,h + "\n\n");
            this.historial.Insert(0,$"Fecha: {DateTime.Now.ToShortDateString().ToString()} \n\n");
            a.Historial = historial.ToString();

            this.rtbHistorial.Text = a.Historial;
        }

        private void rtbHistorial_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = this.IndiceAnimal(this.cmbMascota.SelectedItem.ToString());
            CargarListaAnimales();
            this.rtbHistorial.Text = animales[indice].Historial;
            this.lblDatoNombre.Text = animales[indice].Nombre;
            this.lblDatoEdad.Text = animales[indice].Edad.ToString();
            this.lblDatoRaza.Text = animales[indice].Raza;
            this.lblDatoTipo.Text = animales[indice].Tipo.ToString();
            //this.rtbHistorial.Text = animalesXml.Lista[indice].Historial;
            //this.lblDatoNombre.Text = animalesXml.Lista[indice].Nombre;
            //this.lblDatoEdad.Text = animalesXml.Lista[indice].Edad.ToString();
            //this.lblDatoRaza.Text = animalesXml.Lista[indice].Raza;
            //this.lblDatoTipo.Text = animalesXml.Lista[indice].Tipo.ToString();
        }

        int[] ConvertirListaAArray(int[] listaAAgregar, int id)
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
            this.animales.Clear();

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
                MessageBox.Show("La lista está vacia");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
