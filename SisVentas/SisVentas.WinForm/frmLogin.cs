using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVentas.WinForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if ((TxtUsuario.Text != "") && (TxtPassword.Text != ""))
            {
                if ((TxtUsuario.Text.Equals("admin")) && (TxtPassword.Text.Equals("admin")))
                {
                    frmPrincipal miPrincipal = new frmPrincipal();
                    miPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o conraseña incorrecto", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUsuario.Clear();
                    TxtPassword.Clear();
                    TxtUsuario.Focus();

                }
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtUsuario.Focus();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
