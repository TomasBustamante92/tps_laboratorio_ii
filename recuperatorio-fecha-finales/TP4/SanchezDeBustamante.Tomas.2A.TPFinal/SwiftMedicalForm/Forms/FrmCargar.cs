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
        Serializador<Duenio> dueniosSql = null;
        Serializador<Mascota> mascotasSql = null;
        FrmDuenio frmDuenio;
        DialogResult resultado;

        public FrmCargar()
        {
            InitializeComponent();
            this.dueniosSql = new Serializador<Duenio>();
            this.mascotasSql = new Serializador<Mascota>();
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
            try
            {
                CargarListbox();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudieron cargar las listas!");
            }
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
        /// Si se cambia el texto se busca un match de lo que ingreso el usuario con la lista de duenios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.txtBuscarNombre.Text))
            {
                this.lbListaDuenios.DataSource = this.dueniosSql.Lista;
            }
            else
            {
                this.lbListaDuenios.DataSource = null;
                this.lbListaDuenios.Items.Clear();

                foreach (Duenio item in this.dueniosSql.Lista)
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
                    aux.Activo = false;
                    DuenioDAO.ModificarDuenioSql(aux);
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
        /// Recibe un objeto Duenio y devuelve la cantidad de mascotas
        /// </summary>
        /// <param name="duenio"></param>
        /// <returns></returns>
        public int ContarMascotasPorDuenio(Duenio duenio)
        {
            int contador = 0;

            foreach (Mascota mascota in this.mascotasSql.Lista)
            {
                if(duenio.Id == mascota.IdDuenio && mascota.Activo)
                {
                    contador++;
                }
            }

            return contador;
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
                frmDuenio = new FrmDuenio(aux);

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
            this.lbListaDuenios.Items.Clear();
            CargarListas();

            if(this.dueniosSql.Lista is not null)
            {
                foreach (Duenio duenio in this.dueniosSql.Lista)
                {
                    if (duenio.Activo)
                    {
                        duenio.ContarMascotasPorDuenio += ContarMascotasPorDuenio;
                        this.lbListaDuenios.Items.Add(duenio);
                    }
                }
            }
        }

        /// <summary>
        /// Carga las listas de duenios y mascotas
        /// </summary>
        public void CargarListas()
        {
            try
            {
                this.dueniosSql.Lista.Clear();
                this.mascotasSql.Lista.Clear();
                DuenioDAO.CargarDueniosSql(dueniosSql);
                MascotaDAO.CargarMascotasSql(mascotasSql);
            }
            catch (MascotaModificadaException)
            {
                MessageBox.Show("ERROR!!! Un tipo de mascota fue modificado fuera del programa");
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudieron cargar las listas!");
            }
        }

        /// <summary>
        /// boton para exportar los datos en JSON o XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo JSON|*.json|Archivo XML|*.xml";
            string path;
            int xmlJson;

            try
            {
                saveFileDialog.ShowDialog();
                path = saveFileDialog.FileName;
                xmlJson = EvaluarXmlJson(path);

                if(xmlJson == 1)
                {
                    this.dueniosSql.GuardarListaJson(path);
                }
                else if(xmlJson == 2)
                {
                    this.dueniosSql.GuardarListaXml(path);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("El tipo de archivo elegido no es compatible");
            }
            catch (ArchivoNoEncontradoException)
            {
                MessageBox.Show("ERROR!!! No se pudieron encontrar los archivos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// boton para importar archivos JSON o XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo JSON|*.json|Archivo XML|*.xml";
            Serializador<Duenio> listaAux = new Serializador<Duenio>();
            string path;
            int xmlJson;
            int dueniosNuevos;

            try
            {
                openFileDialog.ShowDialog();
                path = openFileDialog.FileName;
                xmlJson = EvaluarXmlJson(path);

                if (xmlJson == 1)
                {
                    listaAux.CargarListaJson(path);
                }
                else if (xmlJson == 2)
                {
                    listaAux.CargarListaXml(path);
                }

                dueniosNuevos = AgregarDueniosImportados(listaAux);

                MessageBox.Show($"Se importaron {dueniosNuevos} Dueños");
                CargarListbox();
            }
            catch (ArchivoNoEncontradoException) 
            {
                MessageBox.Show("ERROR!!! No se pudieron encontrar los archivos");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("El tipo de archivo elegido no es compatible");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Agrega los duenios que no se encuentren a la lista
        /// </summary>
        /// <param name="listaImportada"></param>
        /// <returns></returns>
        public int AgregarDueniosImportados(Serializador<Duenio> listaImportada)
        {
            int agregados = 0;
            bool esta;
            
            foreach (Duenio aux in listaImportada.Lista)
            {
                esta = false;

                foreach (Duenio duenio in this.dueniosSql.Lista)
                {
                    if(duenio.Equals(aux))
                    {
                        esta = true;
                        break;
                    }
                }

                if(!esta)
                {
                    DuenioDAO.AgregarDuenioSql(aux);
                    agregados++;
                }
            }

            return agregados;
        }

        /// <summary>
        /// Evalua que extension se esta usando
        /// </summary>
        /// <param name="path"></param>
        /// <returns>1 si la extension es JSON, 2 si es XML</returns>
        public int EvaluarXmlJson(string path)
        {
            string extension = System.IO.Path.GetExtension(path);
            int retorno = 0;

            switch (extension.ToLower())
            {
                case ".json":
                    retorno = 1;
                    break;
                case ".xml":
                    retorno = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return retorno;
        }

        /// <summary>
        /// Cierra el form y devuelve un OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
