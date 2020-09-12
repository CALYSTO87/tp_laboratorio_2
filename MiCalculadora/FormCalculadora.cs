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

        private void btnOperar_Click(object sender, EventArgs e)
        {
            //dado que la clase nro no me permite crear otro método operar debo instanciar el 
            //objeto numero desde el form

            if (txtNumero1 != null && txtNumero2 != null && cmbOperador != null)
            {

                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text,cmbOperador.Text).ToString();
            }
            else
                MessageBox.Show("Debe completar todos los campos para la operación");
        }

        private double Operar(string numer1,string numero2, string operador)
        {
            Numero numerotxt1 = new Numero(txtNumero1.Text);

            Numero numerotxt2 = new Numero(txtNumero2.Text);

            return Calculadora.Operar(numerotxt1, numerotxt2, operador);
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void Limpiar()
        {
            lblResultado.ResetText();
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();

            string labelABinario = num.DecimalBinario(lblResultado.Text);

            lblResultado.Text = labelABinario;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();

            string labelADecimal = num.BinarioDecimal(lblResultado.Text);

            lblResultado.Text = labelADecimal;
        }
    }
}
