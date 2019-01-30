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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Crea la instancia del objeto a trabajar
            Categoria categoria = new Categoria();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtNombre.Text.Trim().ToString();
            string descripcion = txtDescripcion.Text.Trim().ToString();

            //Asignamos variables
            categoria.nombre = nombre;
            categoria.descripcion = descripcion;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.CategoriaBLL.insertCategoria(categoria);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getAllCategoria();
               
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            //Crea la instancia del objeto a trabajar
            Categoria categoria = new Categoria();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtNombre.Text.Trim().ToString();
            string descripcion = txtDescripcion.Text.Trim().ToString();
            int id = Convert.ToInt32(txtIdcategoria.Text.Trim().ToString());

            //Asignamos variables
            categoria.nombre = nombre;
            categoria.descripcion = descripcion;
            categoria.id = id;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.CategoriaBLL.updateCategoria(categoria);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido editado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getAllCategoria();

            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string name = txtBuscar.Text;
            List<Categoria> presentacions = new List<Categoria>();
            dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getCategoriaByName(name);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            categoria.nombre = nombre;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.CategoriaBLL.removeCategoria(nombre);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getAllCategoria();

            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getAllCategoria();
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Validar si seleccione la fila
            if (e.RowIndex >= 0)
            {
                //Obtienes la fila seleccionada
                DataGridViewRow row = this.dataListado.Rows[e.RowIndex];

                //Le coloco los datos de los texbox en base a la fila seleccionada
                txtIdcategoria.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            //Declaramos variables y las igualamos a las cajas de texto
            string nombre = txtBuscar.Text.Trim().ToString();

            //Asignamos variables
            categoria.nombre = nombre;

            //Puente entre el BusinessLogicLayer y la interfaz Grafica
            String message = SisVentas.BusinessLogicLayer.CategoriaBLL.removeCategoria(nombre);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                //Si no hubo errores, muestra un mensaje de confirmacion
                MessageBox.Show("El registro ha sido eliminado correctamente");

                //Precargado
                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getAllCategoria();

            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}