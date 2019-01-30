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
            string sexo = cbSexo.SelectedItem.ToString();
            DateTime fecha_nacimiento = dtFechaNac.Value;
            string tipo_documento= cbTipo_Documento.SelectedItem.ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            


            //ASIGNAMOS VARIABLES
            cliente.nombre = nombre;
            cliente.apellido = apellido;
            cliente.sexo = Convert.ToChar(sexo);
            cliente.fecha_nacimiento = fecha_nacimiento;
            cliente.tipo_documento = tipo_documento;
            cliente.direccion = direccion;
            cliente.telefono = telefono;
            cliente.email = email;

            String message = SisVentas.BusinessLogicLayer.ClienteBLL.insertCliente(cliente);

            ////Es para validar si ocurrio algun error

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("la informacion del cliente se ha guardado correctamente");
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.ClienteBLL.getAllClientes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a viajar
            Cliente cliente = new Cliente();

            //Declaramos variables y las igualamos a las cajas de texto

            string codigo = txtIdcliente.Text.Trim().ToString();
            string nombre = txtNombre.Text.Trim().ToString();
            string apellido = txtApellidos.Text.Trim().ToString();
            string sexo = cbSexo.SelectedItem.ToString();
            DateTime fecha_nacimiento = dtFechaNac.Value;
            string tipo_documento = cbTipo_Documento.SelectedItem.ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            int id = Convert.ToInt32(txtIdcliente.Text.Trim().ToString());



            //ASIGNAMOS VARIABLES
            cliente.nombre = nombre;
            cliente.apellido = apellido;
            cliente.sexo = Convert.ToChar(sexo);
            cliente.fecha_nacimiento = fecha_nacimiento;
            cliente.tipo_documento = tipo_documento;
            cliente.direccion = direccion;
            cliente.telefono = telefono;
            cliente.email = email;
            cliente.Id = id;

            String message = SisVentas.BusinessLogicLayer.ClienteBLL.updateCliente(cliente);

            ////Es para validar si ocurrio algun error

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("la informacion del cliente se ha guardado correctamente");
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Declarar e instanciar la lista para almacenar el estudiante a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Se declara la variable de tipo entero
            //int StudentId = 0;

            //Obtiene el id y lo iguala a la caja de texto
            // StudentId = Convert.ToInt32(txtIdSt.Text.Trim().ToString());

            //Hacer el puentre entre la capa de negocio y la UI
            //students = DesApl.BusinessLogicLayer.StudentBLL.getStudentByID(StudentId);

            //Declaro la variable para almacenar el filtro de busqueda
            string filter = string.Empty;
            //declaro una variable para almacenar la bandera
            string flag = string.Empty;

            if (string.IsNullOrEmpty(cbBuscar.SelectedItem.ToString()))
            {
                filter = txtBuscar.Text.Trim().ToString();
                flag = "Documento";
            }
            else
            {
                //filter = cbBuscar.SelectedItem.ToString();
                filter = txtBuscar.Text.Trim().ToString();
                flag = "apellido";
            }


            //Crear el puente entre el BLL y la UI
            clientes = SisVentas.BusinessLogicLayer.ClienteBLL.getClienteByFilter(filter, flag);

            //Mostrar los datos obtenidos en los textbox
            foreach (var i in clientes)
            {
                cbTipo_Documento.Text = i.tipo_documento;
                txtApellidos.Text = i.apellido;
            }

            dataListado.DataSource = clientes;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            //Declaramos variables y las igualamos a las cajas de texto
            string apellido = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            cliente.apellido = txtBuscar.Text;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.ClienteBLL.removeCliente(apellido);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ClienteBLL.getAllClientes();

            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            //Declaramos variables y las igualamos a las cajas de texto
            string apellido = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            cliente.apellido = txtBuscar.Text;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.ClienteBLL.removeCliente(apellido);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ClienteBLL.getAllClientes();

            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Validar si seleccione la fila
            if (e.RowIndex >= 0)
            {
                //Obtienes la fila seleccionada
                DataGridViewRow row = this.dataListado.Rows[e.RowIndex];

                //Le coloco los datos de los texbox en base a la fila seleccionada
                txtIdcliente.Text = row.Cells["id"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtApellidos.Text = row.Cells["apellido"].Value.ToString();
                cbSexo.Text = row.Cells["sexo"].Value.ToString();
                dtFechaNac.Text = row.Cells["fecha_nacimiento"].Value.ToString();
                txtNum_Documento.Text = row.Cells["num_documento"].Value.ToString();
                txtDireccion.Text = row.Cells["direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                
            }
        }
    }
}
