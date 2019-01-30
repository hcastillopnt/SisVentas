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
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Proveedor miProveedor = new Proveedor();
            int codigo = Convert.ToInt32(txtIdproveedor.Text.Trim().ToString());
            string razonSocial = txtRazon_Social.Text.Trim().ToString();
            string numDocumento = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string tipoDocumento = cbTipo_Documento.SelectedItem.ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string url = txtUrl.Text.Trim().ToString();
            string sectorComercial = cbSector_Comercial.SelectedItem.ToString();

            miProveedor.ID = codigo;
            miProveedor.RazonSocial = razonSocial;
            miProveedor.TipoDocumento = tipoDocumento;
            miProveedor.NumDocumento = numDocumento;
            miProveedor.Direccion = direccion;
            miProveedor.Telefono = telefono;
            miProveedor.Email = email;
            miProveedor.URL = url;
            miProveedor.SectorComercial = sectorComercial;

            string message = SisVentas.BusinessLogicLayer.ProveedorBLL.insertProveedor(miProveedor);

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargarndo la informacion del grid por medio de la BD(Actualizada)
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedores();
            }
            else
            {
                //Si hubo algun error muestra un mensaje con este mismo 
                MessageBox.Show(message);
            }       
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Declarar e instanciar la lista para almacenar el estudiante a buscar
            List<Proveedor> proveedores = new List<Proveedor>();

            //Declaro una variable para almacenar el filtro de busqueda
            string filter = string.Empty;
            //Declaro una variable para almacenar la bandera
            string bandera = string.Empty;

            if (string.IsNullOrEmpty(txtIdproveedor.Text.Trim().ToString()))
            {               
                    filter = txtNum_Documento.Text.Trim().ToString();
                    bandera = "NumDocumento";       
            }
            else
            {
                filter = txtIdproveedor.Text.Trim().ToString();
                bandera = "ProveedorID";
            }

            //Crear el puente entre el BLL y la UI
            proveedores = SisVentas.BusinessLogicLayer.ProveedorBLL.getProveedorByFilter(filter, bandera);


            //Mostrar los datos obtenidos en los textbox
            foreach (var i in proveedores)
            {
                txtIdproveedor.Text = i.ID.ToString();
                txtNum_Documento.Text = i.NumDocumento;
            }
            //Cargue en el grid el objeto que busco
            dataListado.DataSource = proveedores;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal miPrincipal = new frmPrincipal();
            miPrincipal.Show();
            this.Hide(); 
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdproveedor.Text = "";
            txtRazon_Social.Text = "";
            txtNum_Documento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtUrl.Text = "";
            txtEmail.Text = "";
        }
    }
}
