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
    public partial class FrmIngreso : Form
    {
        const string PATH = "..\\..\\..\\Archivos";
        Serializador<Duenio> duenios = null;
        Serializador<int> ultimoIds = null; // [0 es Duenios - 1 es Animales]

        public FrmIngreso()
        {
            InitializeComponent();
            this.duenios = new Serializador<Duenio>();
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
            FrmNuevo nuevo = new FrmNuevo(this.duenios, ultimoIds.Lista[0]); // sumarle ID
            FrmMenuDuenio duenioFrm;
            Duenio nuevoDuenio = null;
            DialogResult resultado = nuevo.ShowDialog();
            DialogResult resultadoDuenio;

            if (resultado == DialogResult.OK)
            {
                nuevoDuenio = nuevo.GetDuenio; // REFACTORIZAR PARA PASAR EL DUENIO SELECCIONADO

                if(nuevoDuenio is not null)
                {
                    duenioFrm = new FrmMenuDuenio(nuevoDuenio, ultimoIds.Lista[1]); 

                    this.ultimoIds.Lista[0] = nuevoDuenio.ID;
                    resultadoDuenio = duenioFrm.ShowDialog();
                    this.ultimoIds.Lista[1] = duenioFrm.UltimoId;


                    if (resultadoDuenio != DialogResult.Abort) // SE REPITEE
                    {

                    }
                    else if (resultadoDuenio == DialogResult.Abort)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ta null");
                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            FrmCargarDuenio cargar = new FrmCargarDuenio(this.duenios);
            FrmMenuDuenio duenioFrm;
            DialogResult resultado = cargar.ShowDialog();
            DialogResult resultadoDuenio;

            if (resultado == DialogResult.OK)
            {
                duenioFrm = new FrmMenuDuenio(cargar.GetDuenioElegido(), ultimoIds.Lista[1]);  
                resultadoDuenio = duenioFrm.ShowDialog();
                this.ultimoIds.Lista[1] = duenioFrm.UltimoId;


                if (resultadoDuenio == DialogResult.OK) // SE REPITEE
                {

                }
                else if (resultadoDuenio == DialogResult.Abort)
                {
                    this.Close();
                }
            }
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // CAMBIAR
            //MessageBox.Show(Environment.CurrentDirectory);
            //string path = ".";

            //string path = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                //this.duenios.CargarListaXml(path, "Duenios");
                this.duenios.CargarListaJson(PATH, "Duenios");
                this.ultimoIds.CargarListaJson(PATH, "UltimoId");
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontró la base de datos");
            }
        }

        private void FrmIngreso_FormClosed(object sender, FormClosedEventArgs e)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // CAMBIAR
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //string path = "..\\..\\..\\Archivos";


        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Guardar antes de salir?", "Alerta!",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if(resultado == DialogResult.Yes)
                {
                    MessageBox.Show(this.ultimoIds.Lista[1].ToString());

                    try
                    {
                        //this.duenios.GuardarListaXml(path,"Duenios");
                        this.duenios.GuardarListaJson(PATH, "Duenios");
                        this.ultimoIds.GuardarListaJson(PATH, "UltimoId");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Pasaron cosas");
                    }
                }
                else if(resultado == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
