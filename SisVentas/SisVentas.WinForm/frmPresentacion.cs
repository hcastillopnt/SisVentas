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

            objpresentacion.Id = Convert.ToInt32(txtIdpresentacion.ToString());
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

                if (cbBuscar.Text == "Documento")
                {
                    //se crea la variable para despues alacenar el num a buscar
                    string trabajadorNumDocumento;

                    //obtiene id del textbox
                    trabajadorNumDocumento = txtBuscar.Text.Trim();

                    //puente con el bll
                    if (string.IsNullOrEmpty(trabajadorNumDocumento))
                    {
                        MessageBox.Show("Ingresa el numero de documento (DNI)");
                    }
                    else
                    {
                        presentacions = SisVentas.BusinessLogicLayer.PresentacionBLL.insertPresentacion();
                    }
                }

                if (cbBuscar.Text == "Apellidos")
                {
                    //se crea la variablepara despues alacenar el ap a buscar
                    string trabajadorApellido;

                    //obtiene id del textbox
                    trabajadorApellido = txtBuscar.Text.Trim();

                    //puente con el bll
                    if (string.IsNullOrEmpty(trabajadorApellido))
                    {
                        MessageBox.Show("Ingresa el Apellido");
                    }
                    else
                    {
                        presentacions = SisVentas.BusinessLogicLayer.PresentacionBLL.getTrabajadorByApellido(trabajadorApellido);
                    }
                }

                foreach (var i in trabajadores)
                {
                    txtIdpresentacion.Text = i.Id.ToString();
                    txtNombre.Text = i.Nombre;
                    txtDescripcion.Text = i.Descripcion;
                 
                }

                //cargar datos
                dataListado.DataSource = trabajadores;
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
   
