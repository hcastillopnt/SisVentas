using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisVentas.BusinessEntities;
using SisVentas.BusinessLogicLayer;


namespace SisVentas.WinForm
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.ClienteBLL.getAllClientes();
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Validar si seleccione la fila
            if (e.RowIndex >= 0)
            {
                //Obtengo la fila seleccionada
                DataGridViewRow row = this.dataListado.Rows[e.RowIndex];

                //Le coloco los datos los textbox en base a la fila seleccionada
                txtIdcliente.Text = row.Cells["ID"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
                cbSexo.Text = row.Cells["Sexo"].Value.ToString();
                dtFechaNac.Text = row.Cells["FechaNacimiento"].Value.ToString();
                cbTipo_Documento.Text = row.Cells["TipoDocumento"].Value.ToString();
                txtNum_Documento.Text = row.Cells["NumDocumento"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Delcarar e instanciar la lista para almacenar ek estudiante a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Declaro la variable para almacenar despues el ID a buscar
            //int StudentID = 0;

            //Obteniendo el ID que quiero buscar, por medio de la UI
            //StudentID = Convert.ToInt32(txtIDStudent.Text.Trim().ToString());

            //Hacer el puente entre la capa de negocios y la UI
            //students = ContosoUniversity.BusinessLogicLayer.StudentBLL.getStudentByID(StudentID);

            //Declaro una variable para almacenar el filtro de busqueda
            string filter = string.Empty;

            //Declaro una variable para almacenar la bandera
            string bandera = string.Empty;

            if (string.IsNullOrEmpty(txtIdcliente.Text.Trim().ToString()))
            {
                if (string.IsNullOrEmpty(txtApellidos.Text.Trim().ToString()))
                {
                    filter = txtNombre.Text.Trim().ToString();
                    bandera = "Nombre";
                }
                else
                {
                    filter = txtApellidos.Text.Trim().ToString();
                    bandera = "Apellidos";
                }
            }
            else
            {
                filter = txtIdcliente.Text.Trim().ToString();
                bandera = "ID";
            }


            //Crear el puente entre el BLL y la UI
            clientes = SisVentas.BusinessLogicLayer.ClienteBLL.getClienteByFilter(filter, bandera);

            //Mostrar los datos obtenidos en los textbox
            foreach (var i in clientes)
            {
                txtIdcliente.Text = i.ID.ToString();
                txtApellidos.Text = i.Apellidos;
                txtNombre.Text = i.Nombre;

            }
            //Cargue en el grid el objeto que buscas
            dataListado.DataSource = clientes;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            int id = Convert.ToInt32(txtIdcliente.Text.Trim().ToString());
            String nombre = txtNombre.Text.Trim().ToString();
            String apellidos = txtApellidos.Text.Trim().ToString();
            String sexo = cbSexo.Text.Trim().ToString();
            DateTime fechanacimiento = Convert.ToDateTime(dtFechaNac.Text.Trim().ToString());
            String tipodocumento = cbTipo_Documento.Text.Trim().ToString();
            String numdocumento = txtNum_Documento.Text.Trim().ToString();
            String direccion = txtDireccion.Text.Trim().ToString();
            String telefono = txtTelefono.Text.Trim().ToString();
            String email = txtEmail.Text.Trim().ToString();

            cliente.ID = id;
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.FechaNacimiento = fechanacimiento;
            cliente.TipoDocumento = tipodocumento;
            cliente.NumDocumento = numdocumento;
            cliente.Direccion = direccion;
            cliente.Telefono = telefono;
            cliente.Email = email;

            //Puente entre el BusinessLogicLayer y la Interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.ClienteBLL.insertCliente(cliente);

            //Espara validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargando la informacion del grid por medio de la BD
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ClienteBLL.getAllClientes();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a trabajar
            Cliente cliente = new Cliente();

            //Declaramos variables y las igualamos a las cajas de texto
            int id = Convert.ToInt32(txtIdcliente.Text.Trim().ToString());
            String nombre = txtNombre.Text.Trim().ToString();
            String apellidos = txtApellidos.Text.Trim().ToString();
            String sexo = cbSexo.Text.Trim().ToString();
            DateTime fechanacimiento = Convert.ToDateTime(dtFechaNac.Text.Trim().ToString());
            String tipodocumento = cbTipo_Documento.Text.Trim().ToString();
            String numdocumento = txtNum_Documento.Text.Trim().ToString();
            String direccion = txtDireccion.Text.Trim().ToString();
            String telefono = txtTelefono.Text.Trim().ToString();
            String email = txtEmail.Text.Trim().ToString();

            //Asignamos variables
            cliente.ID = id;
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.FechaNacimiento = fechanacimiento;
            cliente.TipoDocumento = tipodocumento;
            cliente.NumDocumento = numdocumento;
            cliente.Direccion = direccion;
            cliente.Telefono = telefono;
            cliente.Email = email;

            //Puente entre el BusinessLogicLayer y la interfaz grafica
            String message = SisVentas.BusinessLogicLayer.ClienteBLL.updateCliente(cliente);

            //Espara validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargando la informacion del grid por medio de la BD
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ClienteBLL.getAllClientes();

            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a trabajar
            Cliente cliente = new Cliente();

            //Declaramos variables y las igualamos a las cajas de texto
            int id = Convert.ToInt32(txtIdcliente.Text.Trim().ToString());
            String nombre = txtNombre.Text.Trim().ToString();
            String apellidos = txtApellidos.Text.Trim().ToString();
            String sexo = cbSexo.Text.Trim().ToString();
            DateTime fechanacimiento = Convert.ToDateTime(dtFechaNac.Text.Trim().ToString());
            String tipodocumento = cbTipo_Documento.Text.Trim().ToString();
            String numdocumento = txtNum_Documento.Text.Trim().ToString();
            String direccion = txtDireccion.Text.Trim().ToString();
            String telefono = txtTelefono.Text.Trim().ToString();
            String email = txtEmail.Text.Trim().ToString();

            //Asignamos variables
            cliente.ID = id;
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.FechaNacimiento = fechanacimiento;
            cliente.TipoDocumento = tipodocumento;
            cliente.NumDocumento = numdocumento;
            cliente.Direccion = direccion;
            cliente.Telefono = telefono;
            cliente.Email = email;

            //Puente entre el BusinessLogicLayer y la interfaz grafica
            String message = SisVentas.BusinessLogicLayer.ClienteBLL.removeCliente(id);

            //Espara validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargando la informacion del grid por medio de la BD
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ClienteBLL.getAllClientes();

            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
