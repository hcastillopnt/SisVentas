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
            string apellido = txtApellidos.Text.Trim().ToString();
            string sexo = cbSexo.Text;
            DateTime fecha_nacimiento = Convert.ToDateTime(dtFecha_Nacimiento.Text);
            string dni = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string acceso = cbAcceso.Text;
            string usuario = txtUsuario.Text.Trim().ToString();
            string password = txtPassword.Text.Trim().ToString();


            //ASIGNAMOS VARIABLES
            trabajador.nombre = nombre;
            trabajador.apellido = apellido;
            trabajador.sexo = Convert.ToChar(sexo);
            trabajador.fecha_nacimiento = fecha_nacimiento;
            trabajador.num_documento = dni;
            trabajador.direccion = direccion;
            trabajador.telefono = telefono;
            trabajador.email = email;
            trabajador.usuario = usuario;
            trabajador.password = password;

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

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}

