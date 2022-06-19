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
using System.Media;
using System.Threading;
using System.Data.SqlClient;

namespace SwiftMedicalForm
{
    public partial class FrmIngreso : Form
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
        Serializador<Duenio> dueniosSql = null;
        Serializador<Duenio> dueniosSqlOriginal = null;
        Serializador<Mascota> mascotasSql = null;
        Serializador<Mascota> mascotasSqlOriginal = null;
        Serializador<int> ultimoIds = null; // Indice: 0=duenios 1=mascotas
        FrmDuenio frmNuevoDuenio;
        FrmMenuPrincipal frmMenuPrincipal;
        FrmCargar frmCargar;
        DialogResult resultado;
        SoundPlayer player;
        bool estaSonando;
        CancellationTokenSource cancellationTokenSource;
        CancellationToken cancellationToken;
        int ejeX;

        public FrmIngreso()
        {
            InitializeComponent();
            this.dueniosSql = new Serializador<Duenio>();
            this.dueniosSqlOriginal = new Serializador<Duenio>();
            this.mascotasSql = new Serializador<Mascota>();
            this.mascotasSqlOriginal = new Serializador<Mascota>();
            this.ultimoIds = new Serializador<int>();
            this.ultimoIds.Agregar(0);
            this.ultimoIds.Agregar(0);
            player = new SoundPlayer();
            player.SoundLocation = path + "\\ZeldaThemeShop.wav";
            this.ejeX = 825;
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
            frmNuevoDuenio = new FrmDuenio(this.dueniosSql, ultimoIds.Lista[0]);
            resultado = frmNuevoDuenio.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                nuevoDuenio = frmNuevoDuenio.GetDuenio;

                if (nuevoDuenio is not null)
                {
                    frmMenuPrincipal = new FrmMenuPrincipal(this.mascotasSql, nuevoDuenio, ultimoIds.Lista[1]);

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
            frmCargar = new FrmCargar(this.dueniosSql, this.mascotasSql);
            resultado = frmCargar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                frmMenuPrincipal = new FrmMenuPrincipal(mascotasSql, frmCargar.GetDuenioElegido(), ultimoIds.Lista[1]);
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
                this.ultimoIds.CargarListaJson(path, "UltimoId");
                player.PlayLooping();
                estaSonando = true;
                DuenioDAO.CargarDueniosSql(dueniosSql, dueniosSqlOriginal);
                MascotaDAO.CargarMascotasSql(mascotasSql, mascotasSqlOriginal);
                MoverCartel();
            }
            catch (MascotaModificadaException)
            {
                MessageBox.Show("ERROR!!! Un tipo de mascota fue modificado fuera del programa");
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
                        DuenioDAO.GuardarDueniosSql(dueniosSql, dueniosSqlOriginal);
                        MascotaDAO.GuardarMascotasSql(mascotasSql, mascotasSqlOriginal);
                        this.ultimoIds.GuardarListaJson(path, "UltimoId");
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

        /// <summary>
        /// Boton para reproducir musica o pausarla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMusica_Click(object sender, EventArgs e)
        {
            if (estaSonando)
            {
                player.Stop();
                this.btnMusica.ImageIndex = 1;
                this.cancellationTokenSource.Cancel();
                estaSonando = false;
            }
            else
            {
                MoverCartel();
                player.PlayLooping();
                this.btnMusica.ImageIndex = 0;
                estaSonando = true;
            }
        }

        /// <summary>
        /// Crea un hilo nuevo para mover un cartel
        /// </summary>
        private void MoverCartel()
        {
            try
            {
                this.cancellationTokenSource = new CancellationTokenSource();
                this.cancellationToken = this.cancellationTokenSource.Token;
                Task.Run(LoopearCartel, this.cancellationToken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Mientras no se haya cancelado va a mover un cartel de derecha a izquierda
        /// </summary>
        void LoopearCartel()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                IniciarCartel(this.ejeX);
                this.ejeX--;
                Thread.Sleep(10); 

                if (this.ejeX < -450)
                {
                    this.ejeX = 825;
                }
            }
        }

        /// <summary>
        /// Mueve lblAviso de derecha a izquierda
        /// </summary>
        /// <param name="ejeX"></param>
        void IniciarCartel(int ejeX)
        {
            if (this.InvokeRequired)
            {
                DelegadoCartel delegadoCartel = new DelegadoCartel(IniciarCartel);
                this.BeginInvoke(delegadoCartel, new object[] { ejeX });
            }
            else
            {
                this.lblAviso.Left = ejeX;
            }
        }
    }
}
