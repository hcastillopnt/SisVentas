using BusinessEntities;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a trabajar
            Presentacion presentacion = new Presentacion();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtNombre.Text.Trim().ToString();
            string descripcion = txtDescripcion.Text.Trim().ToString();

            //Asignamos variables
            presentacion.nombre = nombre;
            presentacion.descripcion = descripcion;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.PresentacionBLL.insertPresentacion(presentacion);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.PresentacionBLL.getAllPresentacion();

            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a trabajar
            Presentacion presentacion = new Presentacion();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtNombre.Text.Trim().ToString();
            string descripcion = txtDescripcion.Text.Trim().ToString();
            int id = Convert.ToInt32(txtIdpresentacion.Text.Trim().ToString());

            //Asignamos variables
            presentacion.nombre = nombre;
            presentacion.descripcion = descripcion;
            presentacion.id = id;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.PresentacionBLL.updatePresentacion(presentacion);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido editado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.PresentacionBLL.getAllPresentacion();
                
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string name = txtBuscar.Text;
            List<Presentacion> presentacions = new List<Presentacion>();
            dataListado.DataSource = SisVentas.BusinessLogicLayer.PresentacionBLL.getPresentacionByName(name);
           
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.PresentacionBLL.getAllPresentacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a trabajar
            Presentacion presentacion = new Presentacion();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtNombre.Text.Trim().ToString();
            string descripcion = txtDescripcion.Text.Trim().ToString();

            //Asignamos variables
            presentacion.nombre = nombre;
            presentacion.descripcion = descripcion;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.PresentacionBLL.removePresentacion(nombre);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.PresentacionBLL.getAllPresentacion();
                
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
