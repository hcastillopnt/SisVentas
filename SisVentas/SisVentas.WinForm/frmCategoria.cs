using SisVentas.BusinessEntities;
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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            string Nombre = txtNombre.Text.Trim().ToString();
            string Descripcion = txtDescripcion.Text.Trim().ToString();


            categoria.Nombre = Nombre;
            categoria.Descripcion = Descripcion;

            string message = SisVentas.BusinessLogicLayer.CategoriaBLL.updateCategoria(categoria);

            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido actualizado correctamente");

                //Precargarndo la informacion del grid por medio de la BD(Actualizada)
                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.updateCategoria(categoria);
            }
            else
            {
                //Si hubo algun error muestra un mensaje con este mismo 
                MessageBox.Show(message);
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //crea estancia sde modelo a trabajar
            Categoria categoria = new Categoria();
            //agregar valores
            string nombre = txtNombre.Text.Trim().ToString();
            string descripcion = txtDescripcion.Text.Trim().ToString();



            categoria.Nombre = nombre;

            categoria.Descripcion = descripcion;

            //puente entre el bussinessligiclayer y la nterfaz grafica
            string message = SisVentas.BusinessLogicLayer.CategoriaBLL.insertCategoria(categoria);


            // validar si ocurrio un error
            if (string.IsNullOrEmpty(message))
            {
                //si no hay errores manda mensaje de aceptar
                MessageBox.Show("el registro se puso correctamente");

                //la entrada de datos al datagridview
                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getCategorias();
            }
            else
            {
                //si masrca error mandar mensaje
                MessageBox.Show(message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            //crea estancia sde modelo a trabajar
            Categoria categoria = new Categoria();
            //agregar valores
            string nombre = txtBuscar.Text.Trim().ToString();



            categoria.Nombre = nombre;


            //puente entre el bussinessligiclayer y la nterfaz grafica
            string message = SisVentas.BusinessLogicLayer.CategoriaBLL.removeCategoria(nombre);


            // validar si ocurrio un error
            if (string.IsNullOrEmpty(message))
            {
                //si no hay errores manda mensaje de aceptar
                MessageBox.Show("el registro se puso correctamente");

                //la entrada de datos al datagridview
                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getCategorias();
            }
            else
            {
                //si masrca error mandar mensaje
                MessageBox.Show(message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //declarar o instanciar el estudiante
            List<Categoria> categorias = new List<Categoria>();
            //declaro variable para almacenar id a buscar
            String nombre;
            //obtener by id
            nombre = txtBuscar.Text.Trim().ToString();

            //hacer el puente 

            categorias = SisVentas.BusinessLogicLayer.CategoriaBLL.getStudentsByLastName(nombre);
            //cargue e el grid el objeto que buscars
            dataListado.DataSource = categorias;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal miPrincipal = new frmPrincipal();
            miPrincipal.Show();
            this.Hide();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getCategorias();
        }
    }
}
