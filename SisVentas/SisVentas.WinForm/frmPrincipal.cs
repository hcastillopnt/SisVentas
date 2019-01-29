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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo miArticulo = new frmArticulo();
            miArticulo.Show();
            this.Hide();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria miCategoria = new frmCategoria();
            miCategoria.Show();
            this.Hide();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion miPresentacion = new frmPresentacion();
            miPresentacion.Show();
            this.Hide();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso miIngreso = new frmIngreso();
            miIngreso.Show();
            this.Hide();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor miProveedor = new frmProveedor();
            miProveedor.Show();
            this.Hide();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVenta miVenta = new frmVenta();
            miVenta.Show();
            this.Hide();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente miCliente = new frmCliente();
            miCliente.Show();
            this.Hide();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador miTrabajador = new frmTrabajador();
            miTrabajador.Show();
            this.Hide();
        }

        private void ventasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
