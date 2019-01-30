using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemasVentas;
using SisVentas;

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
            //Precargando la informacion del grid por medio de la BD desde el principio
            dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ClienteBLL.getAllClientes();
            txtIdcliente.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //crea la instancia del objeto a trabajar
            Cliente cliente = new Cliente();

            //Asigna alos atributos del objeto


            string nombre = txtNombre.Text.Trim().ToString();
            string apellidos = txtApellidos.Text.Trim().ToString();
            string sexo = cbSexo.SelectedItem.ToString();
            DateTime fechNac = dtFechaNac.Value;
            string tipoDocumento = cbTipo_Documento.SelectedItem.ToString();
            string numerodoc = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string tel = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString(); ;

            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.FechaNacimiento = fechNac;
            cliente.TipoDocumento = tipoDocumento;
            cliente.NumeroDocumento = numerodoc;
            cliente.Direccion = direccion;
            cliente.Telefono = tel;
            cliente.Email = email;

            #region
            //Se valida si ya hay un Id en el textbox si es asi se actualiza en vez de
            //insertar
            if (txtIdcliente.Text != "")
            {
                int Id = Convert.ToInt32(txtIdcliente.Text.Trim());
                cliente.Id = Id;

                //Puente entre le BussinesLogiclayer y la interfaz grafica
                string message = SistemasVentas.BussinesLogicLayer.ClienteBLL.updateCliente(cliente);

                //Es para validar si ocurrio algun error
                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("El registro ha sido actualizado correctamente");

                    //Precargando la informacion del grid por medio de la BD
                    dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ClienteBLL.getAllClientes();
                    bloquear();
                }
                else
                {
                    //si hubo algun error, muestra un mensaje con este mismo
                    MessageBox.Show(message);
                }
            }
            else
            {
                #endregion
                //Puente entre le BussinesLogiclayer y la interfaz grafica
                string message = SistemasVentas.BussinesLogicLayer.ClienteBLL.insertCliente(cliente);

                //Es para validar si ocurrio algun error
                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("El registro ha sido creado correctamente");

                    //Precargando la informacion del grid por medio de la BD
                    dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ClienteBLL.getAllClientes();
                    bloquear();
                }
                else
                {
                    //si hubo algun error, muestra un mensaje con este mismo
                    MessageBox.Show(message);
                }

            }
        }


        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bloquear();
            //declara en instanciar la lista para almacenar el estudiante a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Declaro la variable para almacenar despues el ID a buscar+
            int clienteId = 0;

            //Obteniendo el id que quiero buscar por medio de la UI
            clienteId = Convert.ToInt32(txtBuscar.Text.Trim().ToString());

            //hacer el puente entre la capa de negocios y la UI
            clientes = SistemasVentas.BussinesLogicLayer.ClienteBLL.getClienteByID(clienteId);



            //Mostrar los datos obtenidos en los textbox
            foreach (var i in clientes)
            {
                txtNombre.Text = i.Nombre;
                txtApellidos.Text = i.Apellidos;
                cbSexo.SelectedItem = i.Sexo;
                dtFechaNac.Value = i.FechaNacimiento;
                cbTipo_Documento.SelectedItem = i.TipoDocumento;
                txtNum_Documento.Text = i.NumeroDocumento;
                txtDireccion.Text = i.Direccion;
                txtTelefono.Text = i.Telefono;
                txtEmail.Text = i.Email;


            }

            //Cargar en el grid el objeto que se busca
            dataListado.DataSource = clientes;

        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            desbloquear();
        }

        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            //validar si  seleccione la fila
            if (e.RowIndex >= 0)
            {
                //Obtengo la fila seleccionada
                DataGridViewRow row = this.dataListado.Rows[e.RowIndex];

                //Le coloco los datos los textbox en base a la fila seleccionada
                txtIdcliente.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
                cbSexo.SelectedItem = row.Cells["Sexo"].Value.ToString();
                //dtFechaNac.Value = row.Cells["FechaNacimiento"].;
                cbTipo_Documento.SelectedItem = row.Cells["TipoDocumento"].Value.ToString();
                txtNum_Documento.Text = row.Cells["NumeroDocumento"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();

                bloquear();

            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

        }
        void limpiar()
        {
            txtIdcliente.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            //cbSexo.SelectedItem = row.Cells["Sexo"].Value.ToString();
            //dtFechaNac.Value = row.Cells["FechaNacimiento"].;
           // cbTipo_Documento.SelectedItem = row.Cells["TipoDocumento"].Value.ToString();
            txtNum_Documento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
        
        void bloquear()
        {
            txtIdcliente.Enabled = false;
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            cbSexo.Enabled = false;
            dtFechaNac.Enabled = false;
            cbTipo_Documento.Enabled = false;
            txtNum_Documento.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;

        }
        void desbloquear()
        {
            
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            cbSexo.Enabled = true;
            dtFechaNac.Enabled = true;
            cbTipo_Documento.Enabled = true;
            txtNum_Documento.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            desbloquear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bloquear();
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdcliente.Text != "")
            {
                int clienteid = Convert.ToInt32(txtIdcliente.Text);
                //puente
                string message = SistemasVentas.BussinesLogicLayer.ClienteBLL.removeCliente(clienteid);

                //validacion si hay error
                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("Cliente eliminado correctamente");

                    //cargar en el dgv
                    dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ClienteBLL.getAllClientes();
                    limpiar();

                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione con doble click un cliente a eliminar","Atención");
            }            
        }
    }
}
