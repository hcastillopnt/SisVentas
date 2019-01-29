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
            //***Agregue sola la libreria bussniess entity 
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
                MessageBox.Show("El registro ha sido guardado correctamente");

                dataListado.DataSource = SisVentas.BusinessLogicLayer.CategoriaBLL.getAllCategoria();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}