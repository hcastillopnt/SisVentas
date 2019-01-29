﻿using System;
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

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria categoria = new frmCategoria();
            categoria.ShowDialog();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion presentacion = new frmPresentacion();
            presentacion.ShowDialog();
        }
    }
}
