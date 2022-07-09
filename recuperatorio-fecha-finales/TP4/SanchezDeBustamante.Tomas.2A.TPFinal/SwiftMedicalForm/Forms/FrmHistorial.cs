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
        DialogResult resultado;

        public FrmHistorial()
        {
            InitializeComponent();
        }

        public string Historial
        {
            get { return this.rtbHistorial.Text; }
        }

        /// <summary>
        /// Evalua si el usuario escribió algo, si lo hizo pregunta si esta seguro de volver
        /// sino cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.rtbHistorial.Text))
            {
                resultado = MessageBox.Show("Si vuelve atras se borrarán los datos", "Alerta!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    this.rtbHistorial.Text = string.Empty;
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.rtbHistorial.Text = string.Empty;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Evalua si el usuario escribió algo, si lo hizo pregunta si esta deacuerdo
        /// sino sale un mensaje de alerta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.rtbHistorial.Text))
            {
                resultado = MessageBox.Show("Una vez aceptado no se podrán modificar los datos \n" +
                    "¿esta de acuerdo?", "¿Proceder?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(resultado == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No se puede guardar un historial vacio");
            }
        }

        /// <summary>
        /// Vacia el RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            this.rtbHistorial.Text = string.Empty;
        }
    }
}
