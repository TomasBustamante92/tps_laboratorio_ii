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
        Serializador<Mascota> mascotasSql = null;
        Duenio duenio = null;
        List<Mascota> mascotas;
        StringBuilder historial;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            mascotas = new List<Mascota>();
            this.mascotasSql = new Serializador<Mascota>();
            historial = new StringBuilder();
        }

        public FrmMenuPrincipal(Duenio d) : this()
        {
            this.duenio = d;
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
        /// Abre el form para crear una nueva mascota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            FrmMascota Mascota = new FrmMascota(CargarMascotaEnLista, this.duenio.Id);

            if (Mascota.ShowDialog() == DialogResult.OK)
            {
                CargarListaMascotas();
                CargarForm();
                SeleccionarMascotaRecienCreada();
            }
        }

        /// <summary>
        /// Carga la mascota en la lista
        /// </summary>
        /// <param name="mascota"></param>
        /// <param name="modificar"></param>
        void CargarMascotaEnLista(Mascota mascota, bool modificar)
        {
            try
            {
                if(modificar)
                {
                    if (!MascotaDAO.ModificarMascotaSql(mascota))
                    {
                        MessageBox.Show("La mascota no se pudo modificar!");
                    }
                }
                else
                {
                    if (!MascotaDAO.AgregarMascotaSql(mascota))
                    {
                        MessageBox.Show("La mascota ya está en la base de datos!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar la mascota");
            }
        }

        /// <summary>
        /// Abre el form para agregar una entrada al historial de la mascota seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    MascotaDAO.ModificarMascotaSql(aux); 
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

        /// <summary>
        /// Carga los datos del duenio y mascota para mostrar por pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenuDuenio_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblDatoNombre.Text = string.Empty;
                this.lblDatoEdad.Text = string.Empty;
                this.lblDatoRaza.Text = string.Empty;
                this.lblDatoTipo.Text = string.Empty;
                this.lblNombreDuenio.Text = this.duenio.Nombre;
                this.lblDatoDireccion.Text = this.duenio.Direccion;
                this.lblDatoTelefono.Text = this.duenio.Telefono.ToString();

                CargarListaMascotas();
                CargarForm();
                SeleccionarPrimeraOpcionPorDefault();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No se seleccionó ningun Dueño");
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Carga lo escrito en RichTextBox al historial de la mascota y agrega la fecha
        /// </summary>
        /// <param name="h"></param>
        /// <param name="a"></param>
        void CargarHistorial(string h, Mascota a)
        {
            DateTime d = new DateTime();

            this.historial.Clear();
            this.historial.Append(a.Historial);
            this.historial.Insert(0, "------------------------------------ \n\n");
            this.historial.Insert(0, h + "\n\n");
            this.historial.Insert(0, $"Fecha: {d.AgregarFecha()} \n\n");
            a.Historial = historial.ToString();
            this.rtbHistorial.Text = a.Historial;
        }

        /// <summary>
        /// Actualiza informacion a mostrar en el form
        /// </summary>
        void CargarForm()
        {
            ActualizarHistorial();
            CargarMascotasEnComboBox();
        }

        /// <summary>
        /// Carga el RichTexBox con el historial de la mascota
        /// </summary>
        /// <returns></returns>
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
            else
            {
                this.rtbHistorial.Text = string.Empty;
            }
            return false;
        }

        /// <summary>
        /// Cambia los datos mostrados en pantalla por los de la mascota
        /// seleccionada en el ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else
            {
                this.lblDatoNombre.Text = string.Empty;
                this.lblDatoEdad.Text = string.Empty;
                this.lblDatoRaza.Text = string.Empty;
                this.lblDatoTipo.Text = string.Empty;
                this.rtbHistorial.Text = string.Empty;
            }
        }

        /// <summary>
        /// Abre un form para modificar los datos de la mascota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Mascota aux;
            FrmMascota modificar;

            if (this.cmbMascota.SelectedItem is not null)
            {
                aux = (Mascota)this.cmbMascota.SelectedItem;
                modificar = new FrmMascota(CargarMascotaEnLista, this.mascotasSql, aux);
                modificar.ShowDialog();
                CargarListaMascotas();
                CargarMascotasEnComboBox();
                this.cmbMascota.SelectedItem = aux;
            }
        }

        /// <summary>
        /// Exporta los datos del duenio y mascota a un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Asocia el idMascotas de duenio con el id de mascota y los agrega a la lista
        /// </summary>
        void CargarListaMascotas()
        {
            this.mascotas.Clear();
            CargarListaMascotasSql();
            try
            {
                foreach (Mascota mascota in this.mascotasSql.Lista)
                {
                    if (this.duenio.Id == mascota.IdDuenio && mascota.Activo)
                    {
                        this.mascotas.Add(mascota);
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

        /// <summary>
        /// Actualiza el ComboBox
        /// </summary>
        void CargarMascotasEnComboBox()
        {
            this.cmbMascota.DataSource = null;
            this.cmbMascota.Items.Clear();
            this.cmbMascota.DataSource = this.mascotas;
        }

        /// <summary>
        /// Apenas se abre el form de existir una mascota elige la primer opción
        /// </summary>
        void SeleccionarPrimeraOpcionPorDefault()
        {
            if (this.mascotas.Count != 0)
            {
                this.cmbMascota.SelectedItem = this.cmbMascota.Items[0];
            }
            else
            {
                this.cmbMascota.SelectedItem = null;
            }
        }

        /// <summary>
        /// Despues de crear una mascota se elige la ultima en el ComboBox
        /// </summary>
        void SeleccionarMascotaRecienCreada()
        {
            this.cmbMascota.SelectedItem = this.cmbMascota.Items[this.mascotas.Count - 1];
        }

        /// <summary>
        /// Pregunta al usuario donde quiere guardar el archivo y lo guarda
        /// </summary>
        /// <param name="contenido"></param>
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

        /// <summary>
        /// Prepara los datos a guardar en el txt
        /// </summary>
        /// <returns>datos a guardar</returns>
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

        /// <summary>
        /// Elimina un animal de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.cmbMascota.SelectedItem is not null)
            {
                Mascota aux = (Mascota)this.cmbMascota.SelectedItem;

                DialogResult resultado = MessageBox.Show($"¿Esta seguro que desea eliminar a {aux.Nombre}?", "Alerta!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    aux.Activo = false;
                    CargarMascotaEnLista(aux, true);
                    CargarListaMascotas();
                    CargarForm();
                    SeleccionarPrimeraOpcionPorDefault();
                }
            }
        }

        /// <summary>
        /// Carga la lista de mascotas
        /// </summary>
        public void CargarListaMascotasSql()
        {
            try
            {
                this.mascotasSql.Lista.Clear();
                MascotaDAO.CargarMascotasSql(mascotasSql);
            }
            catch (MascotaModificadaException)
            {
                MessageBox.Show("ERROR!!! Un tipo de mascota fue modificado fuera del programa");
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar la lista de mascotas!");
            }
        }
    }
}
