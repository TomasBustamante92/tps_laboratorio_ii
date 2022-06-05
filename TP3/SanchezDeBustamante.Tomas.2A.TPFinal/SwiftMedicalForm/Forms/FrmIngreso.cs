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
        Serializador<int> ultimoIds = null; 

        public FrmIngreso()
        {
            InitializeComponent();
            this.dueniosJson = new Serializador<Duenio>();
            this.mascotasXml = new Serializador<Mascota>();
            this.ultimoIds = new Serializador<int>();
            this.ultimoIds.Agregar(0);
            this.ultimoIds.Agregar(0);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDuenio nuevo = new FrmDuenio(this.dueniosJson, ultimoIds.Lista[0]); 
            FrmMenuPrincipal duenioFrm;
            Duenio nuevoDuenio = null;
            DialogResult resultado = nuevo.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                nuevoDuenio = nuevo.GetDuenio;

                if (nuevoDuenio is not null)
                {
                    duenioFrm = new FrmMenuPrincipal(dueniosJson, mascotasXml, nuevoDuenio, ultimoIds.Lista[1]);

                    this.ultimoIds.Lista[0] = nuevoDuenio.Id;
                    duenioFrm.ShowDialog();
                    this.ultimoIds.Lista[1] = duenioFrm.UltimoId;
                }
                else
                {
                    MessageBox.Show("Error al seleccionar el dueño");
                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            FrmCargar cargar = new FrmCargar(this.dueniosJson);
            FrmMenuPrincipal duenioFrm;
            DialogResult resultado = cargar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                duenioFrm = new FrmMenuPrincipal(dueniosJson, mascotasXml, cargar.GetDuenioElegido(), ultimoIds.Lista[1]);
                duenioFrm.ShowDialog();
                this.ultimoIds.Lista[1] = duenioFrm.UltimoId;
            }
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            string fuenteDeError = string.Empty;
            try
            {
                fuenteDeError = "Duenios"; 
                this.dueniosJson.CargarListaJson(PATH, "Duenios"); 
                fuenteDeError = "UltimoId"; 
                this.ultimoIds.CargarListaJson(PATH, "UltimoId"); 
            }
            catch (ArchivoNoEncontradoException)
            {
                MessageBox.Show($"ERROR!!! El archivo '{fuenteDeError}' no se pudo encontrar");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            string fuenteDeError = string.Empty;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Guardar antes de salir?", "Alerta!",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        fuenteDeError = "Mascotas";
                        this.mascotasXml.GuardarListaXml(PATH, "Mascotas");
                        fuenteDeError = "Duenios";
                        this.dueniosJson.GuardarListaJson(PATH, "Duenios");
                        fuenteDeError = "UltimoId";
                        this.ultimoIds.GuardarListaJson(PATH, "UltimoId");
                    }
                    catch (ArchivoNoEncontradoException)
                    {
                        MessageBox.Show($"No se pudo encontrar el archivo {fuenteDeError}");
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
