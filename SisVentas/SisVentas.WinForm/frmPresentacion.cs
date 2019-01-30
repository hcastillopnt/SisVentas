using SisVentas.BusinessEntities;
using SisVentas.BusinessLogicLayer;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            txtNombre.Clear();
            txtDescripcion.Clear();
            txtIdpresentacion.Clear();



        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //declarar e instanciar lista
            List<Presentacion> presentacions = new List<Presentacion>();

            string presentacionNom = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(presentacionNom))
            {
                MessageBox.Show("Ingresa el nombre");
            }
            else
            {
                presentacions = SisVentas.BusinessLogicLayer.PresentacionBLL.getPresentacionByNombre(presentacionNom);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            frmPrincipal miPrincipal = new frmPrincipal();
            miPrincipal.Show();
            this.Hide();


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int PresentacionId = Convert.ToInt32(txtIdpresentacion.Text.Trim().ToString());


            string message = SisVentas.BusinessLogicLayer.PresentacionBLL.deletePresentacion(PresentacionId);

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores muestra un mensaje de confirmacion
                MessageBox.Show("El registro se ha eliminado correctamente");

                //Precargarndo la informacion del grid por medio de la BD(Actualizada)
                dataListado.DataSource = SisVentas.BusinessLogicLayer.PresentacionBLL.deletePresentacion(PresentacionId);
            }
            else
            {
                //Si hubo algun error muestra un mensaje con este mismo 
                MessageBox.Show(message);
            }
        }
    }
}




