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
    public partial class FrmIngreso : Form
    {
        const string PATH = "..\\..\\..\\Archivos";
        Serializador<Duenio> dueniosJson = null;
        Serializador<Mascota> mascotasXml = null;
        Serializador<int> ultimoIds = null; // 0=duenios 1=mascotas
        FrmDuenio frmNuevoDuenio;
        FrmMenuPrincipal frmMenuPrincipal;
        FrmCargar frmCargar;
        DialogResult resultado;

        public FrmIngreso()
        {
            InitializeComponent();
            this.dueniosJson = new Serializador<Duenio>();
            this.mascotasXml = new Serializador<Mascota>();
            this.ultimoIds = new Serializador<int>();
            this.ultimoIds.Agregar(0); 
            this.ultimoIds.Agregar(0); 
        }

        /// <summary>
        /// Cierra la App
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Abre un form para crear un nuevo duenio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Duenio nuevoDuenio = null;
            frmNuevoDuenio = new FrmDuenio(this.dueniosJson, ultimoIds.Lista[0]); 
            resultado = frmNuevoDuenio.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                nuevoDuenio = frmNuevoDuenio.GetDuenio;

                if (nuevoDuenio is not null)
                {
                    frmMenuPrincipal = new FrmMenuPrincipal(dueniosJson, mascotasXml, nuevoDuenio, ultimoIds.Lista[1]);
                    this.ultimoIds.Lista[0] = nuevoDuenio.Id;
                    frmMenuPrincipal.ShowDialog();
                    this.ultimoIds.Lista[1] = frmMenuPrincipal.UltimoId;
                }
                else
                {
                    MessageBox.Show("Error al seleccionar el dueño");
                }
            }
        }

        /// <summary>
        /// Abre un form para ver la lista de duenios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmCargar = new FrmCargar(this.dueniosJson, this.mascotasXml);
            resultado = frmCargar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                frmMenuPrincipal = new FrmMenuPrincipal(dueniosJson, mascotasXml, frmCargar.GetDuenioElegido(), ultimoIds.Lista[1]);
                frmMenuPrincipal.ShowDialog();
                this.ultimoIds.Lista[1] = frmMenuPrincipal.UltimoId;
            }
        }

        /// <summary>
        /// Lee los archivos Json de duenios y ultimoId y los carga a la lista Serializador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            try
            {
                this.dueniosJson.CargarListaJson(PATH, "Duenios"); 
                this.ultimoIds.CargarListaJson(PATH, "UltimoId");
                this.mascotasXml.CargarListaXml(PATH, "Mascotas");
            }
            catch (ArchivoNoEncontradoException)
            {
                MessageBox.Show($"ERROR!!! No se pudieron encontrar los archivos");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Pregunta al usuario si desea guardar antes de salir
        /// Caso que si guarda los archivos duenios, mascotas y ultimoId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                resultado = MessageBox.Show("¿Guardar antes de salir?", "Alerta!",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        this.mascotasXml.GuardarListaXml(PATH, "Mascotas");
                        this.dueniosJson.GuardarListaJson(PATH, "Duenios");
                        this.ultimoIds.GuardarListaJson(PATH, "UltimoId");
                    }
                    catch (ArchivoNoEncontradoException)
                    {
                        MessageBox.Show($"ERROR!!! No se pudieron encontrar los archivos");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (resultado == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
