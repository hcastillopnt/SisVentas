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

            //Puente entre le BussinesLogiclayer y la interfaz grafica
            string message = SistemasVentas.BussinesLogicLayer.ClienteBLL.insertCliente(cliente);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargando la informacion del grid por medio de la BD
                dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ClienteBLL.getAllClientes();

            }
            else
            {
                //si hubo algun error, muestra un mensaje con este mismo
                MessageBox.Show(message);
            }

        }



        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
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
    }
}
