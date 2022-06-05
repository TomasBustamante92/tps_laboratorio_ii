using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace SwiftMedicalForm
{
    public partial class FrmMenuPrincipal : Form
    {
        const string PATH = "..\\..\\..\\Archivos";
        Serializador<Mascota> mascotasXml = null;
        Serializador<Duenio> dueniosJson = null;
        Duenio duenio = null;
        List<Mascota> mascotas;
        StringBuilder historial;
        int ultimoIdmascota;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            mascotas = new List<Mascota>();
            historial = new StringBuilder();
        }

        public FrmMenuPrincipal(Serializador<Duenio> dueniosJson, Serializador<Mascota> mascotasXml, 
            Duenio d, int ultimoIdmascota) : this()
        {
            this.mascotasXml = mascotasXml;
            this.dueniosJson = dueniosJson;
            this.duenio = d;
            this.ultimoIdmascota = ultimoIdmascota;
        }

        public int UltimoId
        {
            get { return this.ultimoIdmascota; }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            FrmMascota Mascota = new FrmMascota(this.mascotasXml, this.ultimoIdmascota);

            if(Mascota.ShowDialog() == DialogResult.OK)
            {
                this.duenio.IdMascotas = AgregarId(this.duenio.IdMascotas, Mascota.Mascota.Id); 
                this.ultimoIdmascota = Mascota.UltimoId;

                CargarListaMascotas();
                CargarForm();
                SeleccionarMascotaRecienCreada();
            }
        }

        private void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            FrmHistorial historial = new FrmHistorial();
            Mascota aux;

            if (this.cmbMascota.SelectedItem is not null)
            {
                try
                {
                    aux = (Mascota)this.cmbMascota.SelectedItem;
                    if (historial.ShowDialog() == DialogResult.OK)
                    {
                        CargarHistorial(historial.Historial, aux);
                    }
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
            CargarListaMascotas();
            CargarForm();
            SeleccionarPrimeraOpcionPorDefault();
        }

        void CargarForm()
        {
            ActualizarHistorial();
            CargarMascotasEnComboBox();
        }

        void CargarHistorial(string h, Mascota a)
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
            Mascota aux;

            if (this.cmbMascota.SelectedItem is not null)
            {
                try
                {
                    aux = (Mascota)this.cmbMascota.SelectedItem;
                    this.rtbHistorial.Text = aux.Historial;

                    return true;
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
            Mascota aux = (Mascota)this.cmbMascota.SelectedItem;
            if(aux is not null)
            {
                this.rtbHistorial.Text = aux.Historial;
                this.lblDatoNombre.Text = aux.Nombre;
                this.lblDatoEdad.Text = aux.Edad.ToString();
                this.lblDatoRaza.Text = aux.Raza;
                this.lblDatoTipo.Text = aux.Tipo.ToString();
            }
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

        void CargarArchivoXml()
        {
            try
            {
                this.mascotasXml.CargarListaXml(PATH, "Mascotas");
            }
            catch
            {
                MessageBox.Show("No se pudo cargar el archivo Mascotas");
            }
        }

        void CargarListaMascotas()
        {
            this.mascotas.Clear(); 
            try
            {
                foreach (Mascota item in this.mascotasXml.Lista)
                {
                    foreach (int idMascota in this.duenio.IdMascotas)
                    {
                        if (idMascota == item.Id)
                        {
                            this.mascotas.Add(item);
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
            this.cmbMascota.DataSource = null;
            this.cmbMascota.Items.Clear();
            this.cmbMascota.DataSource = this.mascotas;
        }

        void SeleccionarPrimeraOpcionPorDefault()
        {
            if (this.mascotas.Count != 0)
            {
                this.cmbMascota.SelectedItem = this.cmbMascota.Items[0];
            }
        }

        void SeleccionarMascotaRecienCreada()
        {
            this.cmbMascota.SelectedItem = this.cmbMascota.Items[this.mascotas.Count - 1];
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarArchivo(DatosDeMascota());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ExportarArchivo(string contenido)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivo de texto|.txt";
            DialogResult result = save.ShowDialog();
            string path = save.FileName;

            if(result == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(contenido);
                }
            }
        }

        string DatosDeMascota()
        {
            StringBuilder sb = new StringBuilder();
            Mascota aux;

            sb.AppendLine(" * Dueño:");
            sb.AppendLine($"Nombre: {this.duenio.Nombre}");
            sb.AppendLine($"Teléfono: {this.duenio.Telefono}");
            sb.AppendLine($"Dirección: {this.duenio.Direccion}");
            sb.AppendLine("\n\n * Mascota:");

            if (this.cmbMascota.SelectedItem is not null)
            {
                aux = (Mascota)this.cmbMascota.SelectedItem;

                sb.AppendLine($"Nombre: {aux.Nombre}");
                sb.AppendLine($"Edad: {aux.Edad}");
                sb.AppendLine($"Raza: {aux.Raza}");
                sb.AppendLine("\n - Historial:");
                sb.AppendLine(aux.Historial);
            }

            return sb.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Mascota aux;
            FrmMascota modificar;

            if (this.cmbMascota.SelectedItem is not null)
            {
                aux = (Mascota)this.cmbMascota.SelectedItem;
                modificar = new FrmMascota(this.mascotasXml, aux);
                modificar.ShowDialog();
                CargarMascotasEnComboBox();
                this.cmbMascota.SelectedItem = aux;
            }
        }
    }
}
