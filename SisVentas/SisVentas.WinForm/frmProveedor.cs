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


namespace formProveedor 
{
    public partial class frmProveedor : Form
    {
        public void Form()
        {
            InitializeComponent();
        }

        private void buttonguardar_Click(object sender, EventArgs e)
        {
            //crea la instancia del objeto a trabajar
           frmProveedor Proveedor = new frmProveedor();

            //Asigna alos atributos del objeto
            string ProveedorID = txtBuscar.Text.Trim().ToString();
          

            //Puente entre le BussinesLogiclayer y la interfaz grafica
            string message = SistemasVentas.BussinesLogicLayer.ProveedorBLL.insertProveedor(Proveedor);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargando la informacion del grid por medio de la BD
                gvProveedor.DataSource = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getAllProveedors();

            }
            else
            {
                //si hubo algun error, muestra un mensaje con este mismo
                MessageBox.Show(message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Precargando la informacion del grid por medio de la BD desde el principio
            gvProveedor.DataSource = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getAllProveedors();
        }

        private void buttonbuscar_Click(object sender, EventArgs e)
        {

            //declara en instanciar la lista para almacenar el estudiante a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Declaro la variable para almacenar despues el ID a buscar+
             int ProveedorID = 0;

            //Obteniendo el id que quiero buscar por medio de la UI
            ProveedorID = Convert.ToInt32(txtid.Text.Trim().ToString());

            //hacer el puente entre la capa de negocios y la UI
            Proveedors = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getProveedorByID(ProveedorID);

            //Declaro una variable para almacenar el filtro de busqueda
            string filter = string.Empty;

            if (string.IsNullOrEmpty(txtid.Text.Trim().ToString()))
            {
                filter = txtid.Text.Trim().ToString();
                bandera = "ProveedorId";
            }

            //crear el puente entre el BLL y la UI
            Proveedors = SistemasVentas.BussinesLogicLayer.ProveedorBLL.getProveedorByFilter(filter);

            //Mostrar los datos obtenidos en los textbox
            foreach (var i in Proveedors)
            {
           
                txtid.Text = i.Id.ToString();
            }

            //Cargar en el grid el objeto que se busca
            gvProveedor.DataSource = Proveedors;
}

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
