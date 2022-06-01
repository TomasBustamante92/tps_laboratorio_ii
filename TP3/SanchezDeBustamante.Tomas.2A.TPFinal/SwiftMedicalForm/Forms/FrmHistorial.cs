using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftMedicalForm
{
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
        }

        public string Historial
        {
            get { return this.rtbHistorial.Text; }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.rtbHistorial.Text = string.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {

        }
    }
}
