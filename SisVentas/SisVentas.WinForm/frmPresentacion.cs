using SisVentas.BusinessEntities;
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
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Presentacion objpresentacion = new Presentacion();

            objpresentacion.ID = Convert.ToInt32(txtIdpresentacion.ToString());
            objpresentacion.Nombre = txtNombre.Text.Trim().ToString();
            objpresentacion.Descripcion = txtDescripcion.Text.Trim().ToString();

            string message = BusinessLogicLayer.PresentacionBLL.insertPresentacion(objpresentacion);

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro ha sido guradado correctamente");

                txtIdpresentacion.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
