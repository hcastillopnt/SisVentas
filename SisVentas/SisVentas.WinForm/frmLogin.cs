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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if ((TxtUsuario.Text != "") && (TxtPassword.Text != ""))
            {
                if ((TxtUsuario.Text.Equals("guille")) && (TxtPassword.Text.Equals("guille123")))
                {
                    frmPrincipal principal = new frmPrincipal();
                    principal.Show();
                    this.Hide(); //ocultar formulario con el que se esta trabajando ej."Login" 
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña son incorrectas",
                                    "Login",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    TxtUsuario.Clear();
                    TxtPassword.Clear();
                    TxtPassword.Focus();
                    TxtUsuario.Focus();
                }

            }
            else
            {
                MessageBox.Show("Esbribe el usuario y contraseña",
                                 "Login",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
                TxtUsuario.Focus();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
