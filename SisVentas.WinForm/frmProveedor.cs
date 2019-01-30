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

            if (cbBuscar.Text == "Documento")
            {
                //se crea la variable para despues alacenar el num a buscar
                string NumDocumento;

                //obtiene id del textbox
                NumDocumento = txtBuscar.Text.Trim();

                //puente con el bll
                if (string.IsNullOrEmpty(NumDocumento))
                {
                    MessageBox.Show("Ingresa el numero de documento (DNI)");
                }
                else
                {
                    proveedores = SisVentas.BusinessLogicLayer.ProveedorBLL.getStudentByNumDocumento(NumDocumento);
                }
            }

            if (cbBuscar.Text == "Razon Social")
            {
                //se crea la variablepara despues alacenar el ap a buscar
                string RazonSocial;

                //obtiene id del textbox
                RazonSocial = txtBuscar.Text.Trim();

                //puente con el bll
                if (string.IsNullOrEmpty(RazonSocial))
                {
                    MessageBox.Show("Ingresa la razón social");
                }
                else
                {
                    proveedores = SisVentas.BusinessLogicLayer.ProveedorBLL.getProveedorByRazonSocial(RazonSocial);
                }
            }

            foreach (var i in proveedores)
            {
                txtIdproveedor.Text = i.ID.ToString();
                txtDireccion.Text = i.Direccion;
                txtTelefono.Text = i.Telefono;
                txtUrl.Text = i.URL;
                txtEmail.Text = i.Email;
                txtNum_Documento.Text = i.NumDocumento;
                txtRazon_Social.Text = i.RazonSocial;

            }

            //cargar datos
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

        private void btnEditar_Click(object sender, EventArgs e)
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

            string message = SisVentas.BusinessLogicLayer.ProveedorBLL.updateProveedor(miProveedor);

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido actualizado correctamente");

                //Precargarndo la informacion del grid por medio de la BD(Actualizada)
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedores();
            }
            else
            {
                //Si hubo algun error muestra un mensaje con este mismo 
                MessageBox.Show(message);
            }
        
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor miProveedor = new Proveedor();
            int id = Convert.ToInt32(txtIdproveedor.Text.Trim().ToString());
            string razonSocial = txtRazon_Social.Text.Trim().ToString();
            string numDocumento = txtNum_Documento.Text.Trim().ToString();
            string direccion = txtDireccion.Text.Trim().ToString();
            string tipoDocumento = cbTipo_Documento.SelectedItem.ToString();
            string telefono = txtTelefono.Text.Trim().ToString();
            string email = txtEmail.Text.Trim().ToString();
            string url = txtUrl.Text.Trim().ToString();
            string sectorComercial = cbSector_Comercial.SelectedItem.ToString();

            miProveedor.ID = id;
            miProveedor.RazonSocial = razonSocial;
            miProveedor.TipoDocumento = tipoDocumento;
            miProveedor.NumDocumento = numDocumento;
            miProveedor.Direccion = direccion;
            miProveedor.Telefono = telefono;
            miProveedor.Email = email;
            miProveedor.URL = url;
            miProveedor.SectorComercial = sectorComercial;

            string message = SisVentas.BusinessLogicLayer.ProveedorBLL.removeProveedor(id);

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargarndo la informacion del grid por medio de la BD(Actualizada)
                dataListado.DataSource = SisVentas.BusinessLogicLayer.ProveedorBLL.getAllProveedores();
            }
            else
            {
                //Si hubo algun error muestra un mensaje con este mismo 
                MessageBox.Show(message);
            }
        }
    }    
}
