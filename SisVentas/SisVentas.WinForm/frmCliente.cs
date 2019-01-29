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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a viajar
            Cliente cliente = new Cliente();

            //Declaramos variables y las igualamos a las cajas de texto
         
            string codigo = txtIdcliente.Text.Trim().ToString();
            string nombre = txtNombre.Text.Trim().ToString();
            string apellido = txtApellidos.Text.Trim().ToString();
            string sexo = cbSexo.Text;
            DateTime fecha_nacimiento = Convert.ToDateTime(dtFechaNac.Text);
            string tipo_documento= cbTipo_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            


            //ASIGNAMOS VARIABLES
            //****verificar como se pondra el de CODIGO***

            //cliente.Id = codigo;
            cliente.nombre = nombre;
            cliente.apellido = apellido;
            //cliente.sexo = sexo;
            cliente.fecha_nacimiento = fecha_nacimiento;
            cliente.tipo_documento = tipo_documento;
            cliente.direccion = direccion;
            cliente.telefono = telefono;
            cliente.email = email;

            //String message = SisVentas.BusinessLogicLayer.ClienteBLL.insertCliente(cliente);

            ////Es para validar si ocurrio algun error

            //if (string.IsNullOrEmpty(message))
            //{
            //    //Si no hubo errores, muestra un mensaje de confirmacion
            //    MessageBox.Show("la informacion del cliente se ha guardado correctamente");
            //}
            //else
            //{
            //    MessageBox.Show(message);
            //}
        }
    }
}
