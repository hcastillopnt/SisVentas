using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//agregadas
using SisVentas.BusinessEntities;
using SisVentas.BusinessLogicLayer;

namespace SisVentas.WinForm
{
    public partial class frmTrabajador : Form
    {
        public frmTrabajador()
        {
            InitializeComponent();
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            txtIdtrabajador.Enabled = false;
            //precargar info de la bd
            dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajadores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Trabajador trabajador = new Trabajador();
            trabajador.Nombre = txtNombre.Text;
            trabajador.Apellidos = txtApellidos.Text;
            trabajador.Sexo = cbSexo.Text;
            trabajador.FechaNacimiento = dtFecha_Nacimiento.Value;
            trabajador.NumDocumento = txtNumDocumento.Text;
            trabajador.Direccion = txtDireccion.Text;
            trabajador.Telefono = txtTelefono.Text;
            trabajador.Email = txtEmail.Text;
            trabajador.Acceso = cbAcceso.Text;
            trabajador.Usuario = txtUsuario.Text;
            trabajador.Contraseña = txtPassword.Text;

            string message = SisVentas.BusinessLogicLayer.TrabajadorBLL.insertTrabajador(trabajador);

            //validar si hay error o fue correcto
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro se ha creado correctamente");

                //precargar info de la bd
                dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajadores();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtNumDocumento.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //declarar e instanciar lista
            List<Trabajador> trabajadores = new List<Trabajador>();

            if(cbBuscar.Text == "Documento")
            {
                //se crea la variable para despues alacenar el num a buscar
                string trabajadorNumDocumento;

                //obtiene id del textbox
                trabajadorNumDocumento = txtBuscar.Text.Trim();

                //puente con el bll
                if (string.IsNullOrEmpty(trabajadorNumDocumento))
                {
                    MessageBox.Show("Ingresa el numero de documento (DNI)");
                }
                else
                {
                    trabajadores = SisVentas.BusinessLogicLayer.TrabajadorBLL.getTrabajadorByNumDocumento(trabajadorNumDocumento);
                }
            }

            if (cbBuscar.Text == "Apellidos")
            {
                //se crea la variablepara despues alacenar el ap a buscar
                string trabajadorApellido;

                //obtiene id del textbox
                trabajadorApellido = txtBuscar.Text.Trim();

                //puente con el bll
                if (string.IsNullOrEmpty(trabajadorApellido))
                {
                    MessageBox.Show("Ingresa el Apellido");
                }
                else
                {
                    trabajadores = SisVentas.BusinessLogicLayer.TrabajadorBLL.getTrabajadorByApellido(trabajadorApellido);
                }
            }

            foreach (var i in trabajadores)
            {
                txtIdtrabajador.Text = i.ID.ToString();
                txtNombre.Text = i.Nombre;
                txtApellidos.Text = i.Apellidos;
                cbSexo.Text = i.Sexo;
                dtFecha_Nacimiento.Value = i.FechaNacimiento;
                txtNumDocumento.Text = i.NumDocumento;
                txtDireccion.Text = i.Direccion;
                txtTelefono.Text = i.Telefono;
                txtEmail.Text = i.Email;
                cbAcceso.Text = i.Acceso;
                txtUsuario.Text = i.Usuario;
                txtPassword.Text = i.Contraseña;
            }

            //cargar datos
            dataListado.DataSource = trabajadores;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal miPrincipal = new frmPrincipal();
            miPrincipal.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Trabajador trabajador = new Trabajador();
            trabajador.ID = Convert.ToInt16(txtIdtrabajador.Text);
            trabajador.Nombre = txtNombre.Text;
            trabajador.Apellidos = txtApellidos.Text;
            trabajador.Sexo = cbSexo.Text;
            trabajador.FechaNacimiento = dtFecha_Nacimiento.Value;
            trabajador.NumDocumento = txtNumDocumento.Text;
            trabajador.Direccion = txtDireccion.Text;
            trabajador.Telefono = txtTelefono.Text;
            trabajador.Email = txtEmail.Text;
            trabajador.Acceso = cbAcceso.Text;
            trabajador.Usuario = txtUsuario.Text;
            trabajador.Contraseña = txtPassword.Text;

            string message = SisVentas.BusinessLogicLayer.TrabajadorBLL.updateTrabajador(trabajador);

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido actualizado correctamente");

                //Precargarndo la informacion del grid por medio de la BD(Actualizada)
                dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajadores();
            }
            else
            {
                //Si hubo algun error muestra un mensaje con este mismo 
                MessageBox.Show(message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            int trabajadorID = Convert.ToInt32(txtIdtrabajador.Text.Trim().ToString());
           

            string message = SisVentas.BusinessLogicLayer.TrabajadorBLL.deleteTrabajador(trabajadorID);

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores muestra un mensaje de confirmacion
                MessageBox.Show("El registro se ha eliminado correctamente");

                //Precargarndo la informacion del grid por medio de la BD(Actualizada)
                dataListado.DataSource = SisVentas.BusinessLogicLayer.TrabajadorBLL.getAllTrabajadores();
            }
            else
            {
                //Si hubo algun error muestra un mensaje con este mismo 
                MessageBox.Show(message);
            }
        }
    }
}
