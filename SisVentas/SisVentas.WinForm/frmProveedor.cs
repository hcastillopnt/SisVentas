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
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            txtNum_Documento.Enabled = true;
            txtRazon_Social.Enabled = true;
            txtTelefono.Enabled = true;
            txtUrl.Enabled = true;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a viajar
            Proveedor proveedor = new Proveedor();

            //Declaramos variables y las igualamos a las cajas de texto
            string rzs = txtRazon_Social.Text.Trim().ToString();
            string stC = cbSector_Comercial.SelectedItem.ToString();
            string tDoc = cbTipo_Documento.SelectedItem.ToString();
            string dni = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string url = txtUrl.Text.Trim().ToString();


            //ASIGNAMOS VARIABLES
            proveedor.razon_Social = rzs;
            proveedor.sector_Comercial = stC;
            proveedor.tipo_Documento = tDoc;
            proveedor.num_Documento = dni;
            proveedor.direccion = direccion;
            proveedor.telefono = telefono;
            proveedor.email = email;
            proveedor.url = url;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.ProveedorBLL.insertProveedor(proveedor);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El Proveedor ha sido registrado correctamente");

                dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajador();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            txtNum_Documento.Enabled = true;
            txtRazon_Social.Enabled = true;
            txtTelefono.Enabled = true;
            txtUrl.Enabled = true;

            //Crea la instancia del objeto a viajar
            Proveedor proveedor = new Proveedor();

            //Declaramos variables y las igualamos a las cajas de texto
            string rzs = txtRazon_Social.Text.Trim().ToString();
            string stC = cbSector_Comercial.SelectedItem.ToString();
            string tDoc = cbTipo_Documento.SelectedItem.ToString();
            string dni = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string url = txtUrl.Text.Trim().ToString();
            int id = Convert.ToInt32(txtIdproveedor.Text.Trim().ToString());

            //ASIGNAMOS VARIABLES
            proveedor.razon_Social = rzs;
            proveedor.sector_Comercial = stC;
            proveedor.tipo_Documento = tDoc;
            proveedor.num_Documento = dni;
            proveedor.direccion = direccion;
            proveedor.telefono = telefono;
            proveedor.email = email;
            proveedor.url = url;
            proveedor.Id = id;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.ProveedorBLL.updateProveedor(proveedor);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El Proveedor ha sido registrado correctamente");

                dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedor();
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

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedor();
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Validar si seleccione la fila
            if (e.RowIndex >= 0)
            {
                //Obtienes la fila seleccionada
                DataGridViewRow row = this.dataListado.Rows[e.RowIndex];

                //Le coloco los datos de los texbox en base a la fila seleccionada
                txtIdproveedor.Text = row.Cells["id"].Value.ToString();
                txtRazon_Social.Text = row.Cells["razon_Social"].Value.ToString();
                cbSector_Comercial.Text = row.Cells["Sector_Comercial"].Value.ToString();
                cbTipo_Documento.Text = row.Cells["tipo_Documento"].Value.ToString();
                txtNum_Documento.Text = row.Cells["num_Documento"].Value.ToString();
                txtDireccion.Text = row.Cells["direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtUrl.Text = row.Cells["url"].Value.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Declarar e instanciar la lista para almacenar el estudiante a buscar
            List<Proveedor> proveedors = new List<Proveedor>();

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
                flag = "RazonSocial";
            }
         

            //Crear el puente entre el BLL y la UI
            proveedors = SisVentas.BusinessLogicLayer.ProveedorBLL.getProveedorByFilter(filter, flag);

            //Mostrar los datos obtenidos en los textbox
            foreach (var i in proveedors)
            {
                cbTipo_Documento.Text = i.tipo_Documento;
                txtRazon_Social.Text = i.razon_Social;
            }

            dataListado.DataSource = proveedors;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            proveedor.razon_Social = txtBuscar.Text;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.ProveedorBLL.removeProveedor(nombre);

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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            proveedor.razon_Social = txtBuscar.Text;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.ProveedorBLL.removeProveedor(nombre);

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
