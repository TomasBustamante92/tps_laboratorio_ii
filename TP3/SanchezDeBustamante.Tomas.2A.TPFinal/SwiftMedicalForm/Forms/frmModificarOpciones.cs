using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftMedicalForm
{
    public enum modificarOpcion { duenio, mascota, ninguna };

    public partial class frmModificarOpciones : Form
    {
        modificarOpcion opcion;

        public frmModificarOpciones()
        {
            InitializeComponent();
        }

        public modificarOpcion Opcion
        {
            get { return this.opcion; }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificarDuenio_Click(object sender, EventArgs e)
        {
            this.opcion = modificarOpcion.duenio;
            Close();
        }

        private void btnModificarMascota_Click(object sender, EventArgs e)
        {
            this.opcion = modificarOpcion.mascota;
            Close();
        }

        private void frmModificarOpciones_Load(object sender, EventArgs e)
        {
            opcion = modificarOpcion.ninguna;
            SystemSounds.Beep.Play();
        }
    }
}
