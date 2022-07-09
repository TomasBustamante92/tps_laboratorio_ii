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
            frmNuevoDuenio = new FrmDuenio();

            resultado = frmNuevoDuenio.ShowDialog();

            try
            {
                if (resultado == DialogResult.OK)
                {
                    nuevoDuenio = DuenioDAO.BuscarUltimoDuenio();

                    if (nuevoDuenio is not null)
                    {
                        frmMenuPrincipal = new FrmMenuPrincipal(nuevoDuenio);
                        frmMenuPrincipal.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error al seleccionar el dueño");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar al dueño");
            }
        }

        /// <summary>
        /// Abre un form para ver la lista de duenios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmCargar = new FrmCargar();
            resultado = frmCargar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                frmMenuPrincipal = new FrmMenuPrincipal(frmCargar.GetDuenioElegido());
                frmMenuPrincipal.ShowDialog();
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
                MoverCartel();
                player = new SoundPlayer();
                player.SoundLocation = Paths.Archivos + "\\ZeldaThemeShop.wav";
                player.PlayLooping();
                estaSonando = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Boton para reproducir musica o pausarla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMusica_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Hubo un error con el reproductor");
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
