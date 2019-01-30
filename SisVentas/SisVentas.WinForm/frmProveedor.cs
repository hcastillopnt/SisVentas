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

namespace formProveedor
{
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            //Precargando la informacion del grid por medio de la BD desde el principio
            dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getAllProveedors();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //crea la instancia del objeto a trabajar
            Proveedor Proveedor = new Proveedor();

            //Asigna alos atributos del objeto


            string razonsocial = txtRazon_Social.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string sector = cbSector_Comercial.SelectedItem.ToString();
            string tipoDocumento = cbTipo_Documento.SelectedItem.ToString();
            string numdocumento = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string tel = txtTelefono.Text.Trim().ToString();
            string url = txtUrl.Text.Trim().ToString();

            Proveedor.RazonSocial = razonsocial;
            Proveedor.TipoDocumento = tipoDocumento;
            Proveedor.NumeroDocumento = numdocumento;
            Proveedor.Direccion = direccion;
            Proveedor.Telefono = tel;
            Proveedor.Email = email;
            Proveedor.Url = url;

            #region
            //Se valida si ya hay un Id en el textbox si es asi se actualiza en vez de
            //insertar
            if (Convert.ToInt32(txtIdproveedor.Text) > 0)
            {
                int Id = Convert.ToInt32(txtIdproveedor.Text.Trim());
                Proveedor.Id = Id;

                //Puente entre le BussinesLogiclayer y la interfaz grafica
                string message = SistemasVentas.BussinesLogicLayer.ProveedorBLL.updateProveedor(Proveedor);

                //Es para validar si ocurrio algun error
                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("El registro ha sido actualizado correctamente");

                    //Precargando la informacion del grid por medio de la BD
                    dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getAllProveedors();

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
                string message = SistemasVentas.BussinesLogicLayer.ProveedorBLL.insertProveedor(Proveedor);

                //Es para validar si ocurrio algun error
                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("El registro ha sido creado correctamente");

                    //Precargando la informacion del grid por medio de la BD
                    dataListado.DataSource = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getAllProveedors();

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
            //declara en instanciar la lista para almacenar el estudiante a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Declaro la variable para almacenar despues el ID a buscar+
            int ProveedorId = 0;

            //Obteniendo el id que quiero buscar por medio de la UI
            ProveedorId = Convert.ToInt32(txtBuscar.Text.Trim().ToString());

            //hacer el puente entre la capa de negocios y la UI
            Proveedors = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getProveedorByID(ProveedorId);

            

            //Mostrar los datos obtenidos en los textbox
            foreach (var i in Proveedors)
            {
             
                cbTipo_Documento.SelectedItem = i.TipoDocumento;
                txtNum_Documento.Text = i.NumeroDocumento;
                txtDireccion.Text = i.Direccion;
                txtTelefono.Text = i.Telefono;
                txtEmail.Text = i.Email;
                txtRazon_Social.Text = i.RazonSocial;
                txtUrl = i.Url;
            }

            //Cargar en el grid el objeto que se busca
            dataListado.DataSource = Proveedors;

            }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //validar si  seleccione la fila
            if (e.RowIndex >= 0)
            {
                //Obtengo la fila seleccionada
                DataGridViewRow row = this.dataListado.Rows[e.RowIndex];

                //Le coloco los datos los textbox en base a la fila seleccionada
                txtIdproveedor.Text = row.Cells["Id"].Value.ToString();
                cbTipo_Documento.SelectedItem = row.Cells["TipoDocumento"].Value.ToString();
                txtNum_Documento.Text = row.Cells["NumeroDocumento"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtUrl = row.Cells["URL"].Value.ToString();
            }
        }
    }
}
