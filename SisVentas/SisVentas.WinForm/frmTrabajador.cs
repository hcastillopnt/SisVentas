using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntities;

namespace SisVentas.WinForm
{
    public partial class frmTrabajador : Form
    {
        public frmTrabajador()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a viajar
            Trabajador trabajador = new Trabajador();

            //Declaramos variables y las igualamos a las cajas de texto
            string codigo = txtIdtrabajador.Text.Trim().ToString();
            string nombre = txtNombre.Text.Trim().ToString();
            string apellidos = txtApellidos.Text.Trim().ToString();
            string sexo = cbSexo.Text;
            DateTime fecha_nacimiento = Convert.ToDateTime(dtFecha_Nacimiento.Text);
            string dni = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            


            ////Asignamos variables
            //instructor.FirstMidName = nombre;
            //instructor.LastName = apellido;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.TrabajadorBLL.insertTrabajador(trabajador);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El trabajador ha sido registrado correctamente");
            }
            else
            {
                MessageBox.Show(message);
            }
        }

    }
}

