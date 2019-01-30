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
            string nombre = txtNombre.Text.Trim().ToString();
            string apellido = txtApellidos.Text.Trim().ToString();
            string sexo = cbSexo.SelectedItem.ToString();
            DateTime fecha_nacimiento = dtFecha_Nacimiento.Value;
            string dni = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string acceso = cbAcceso.SelectedItem.ToString();
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

                dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajador();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a trabajar
            Trabajador trabajador = new Trabajador();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtNombre.Text.Trim().ToString();
            string apellido = txtApellidos.Text.Trim().ToString();
            string sexo = cbSexo.SelectedItem.ToString();
            DateTime fecha_nacimiento = dtFecha_Nacimiento.Value;
            string dni = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string acceso = cbAcceso.SelectedItem.ToString();
            string usuario = txtUsuario.Text.Trim().ToString();
            string password = txtPassword.Text.Trim().ToString();
            int id = Convert.ToInt32(txtIdtrabajador.Text.Trim().ToString());

            //Asignamos variables
            trabajador.nombre = nombre;
            trabajador.apellido = apellido;
            trabajador.sexo = Convert.ToChar(sexo);
            trabajador.fecha_nacimiento = fecha_nacimiento;
            trabajador.num_documento = dni;
            trabajador.direccion = direccion;
            trabajador.telefono = telefono;
            trabajador.email = email;
            trabajador.acceso = acceso;
            trabajador.usuario = usuario;
            trabajador.password = password;
            trabajador.Id = id;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.TrabajadorBLL.updateTrabajador(trabajador);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido editado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajador();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Declarar e instanciar la lista para almacenar el estudiante a buscar
            List<Trabajador> trabajadors = new List<Trabajador>();

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
            trabajadors = SisVentas.BusinessLogicLayer.TrabajadorBLL.getTrabajadorByFilter(filter, flag);

            //Mostrar los datos obtenidos en los textbox
            foreach (var i in trabajadors)
            {
                txtNum_Documento.Text = i.num_documento;
                txtApellidos.Text = i.apellido;
            }

            dataListado.DataSource = trabajadors;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Trabajador trabajador = new Trabajador();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            trabajador.apellido = txtBuscar.Text;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.TrabajadorBLL.removeTrabajador(nombre);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedor();

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
                txtIdtrabajador.Text = row.Cells["id"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtApellidos.Text = row.Cells["apellido"].Value.ToString();
                //cbSexo.Text = row.Cells["sexo"].Value.ToString();
                dtFecha_Nacimiento.Text = row.Cells["fecha_nacimiento"].Value.ToString();
                txtNum_Documento.Text = row.Cells["num_documento"].Value.ToString();
                txtDireccion.Text = row.Cells["direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                //cbAcceso.Text = row.Cells["acceso"].Value.ToString();
                txtUsuario.Text = row.Cells["usuario"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
            }
        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajador();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            txtNum_Documento.Enabled = true;
            txtApellidos.Enabled = true;
            txtTelefono.Enabled = true;
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            Trabajador trabajador = new Trabajador();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            trabajador.apellido = txtBuscar.Text;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.TrabajadorBLL.removeTrabajador(nombre);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedor();

            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}

