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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.Items.Add("");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double numero1;
            double numero2;

            if (double.TryParse(this.txtNumero1.Text, out numero1) == false)
            {
                MessageBox.Show("Numero 1 incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.cmbOperador.Text == "")
            {
                MessageBox.Show("Operador vacio", "Alerta", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
            }
            else if (double.TryParse(this.txtNumero2.Text, out numero2) == false)
            {
                MessageBox.Show("Numero 2 incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.cmbOperador.Text == "/" && numero2 == 0)
            {
                MessageBox.Show("No se puede dividir por 0", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString(); 
                this.lstOperaciones.Items.Add($"{this.txtNumero1.Text} {this.cmbOperador.Text} {this.txtNumero2.Text} = {this.lblResultado.Text}");
                this.lstOperaciones.SelectedIndex = this.lstOperaciones.Items.Count - 1;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            this.lblResultado.Text = resultado.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            this.lblResultado.Text = resultado.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// Limpia el cache de la aplicación
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
            this.lstOperaciones.Items.Clear();
        }

        /// <summary>
        /// Realiza la operación matematica con los numeros y el operador ingresado por el usuario
        /// </summary>
        /// <param name="numero1">primer numero de la ecuación</param>
        /// <param name="numero2">segundo numero de la ecuación</param>
        /// <param name="operador">operador de la ecuación</param>
        /// <returns>devuelve el resultado de la ecuación</returns>
        private double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1.ToString());
            Operando num2 = new Operando(numero2.ToString());
            char charOperador;
            char.TryParse(operador, out charOperador);
            Calculadora resultado = new Calculadora();

            return resultado.Operar(num1, num2, charOperador);
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if(respuesta != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
