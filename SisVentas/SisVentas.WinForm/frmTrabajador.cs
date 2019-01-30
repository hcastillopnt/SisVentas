using SistemasVentas;
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
    public partial class frmTrabajador : Form
    {
        public frmTrabajador()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //crea la instancia del objeto a trabajar
            Trabajador t = new Trabajador();

            //Asigna alos atributos del objeto
            t.Id = Convert.ToInt32(txtIdtrabajador.Text);
            t.Nombre = txtNombre.Text.Trim().ToString();
            t.Apellidos = txtApellidos.Text.Trim().ToString();
            t.Sexo = Convert.ToString(cbSexo.SelectedValue);
            t.FechaNacimiento = Convert.ToDateTime(dtFecha_Nacimiento);
            t.NumeroDocumento = txtNum_Documento.Text.Trim().ToString();
            t.Direccion = txtDireccion.Text.Trim().ToString();
            t.Telefono = txtTelefono.Text.Trim().ToString();
            string Email= txtEmail.Text.Trim().ToString();
            string Acceso;
        string Usuario;
        string Password;


       
/*
            //Puente entre le BussinesLogiclayer y la interfaz grafica
            string message = ContosoUniversity.BussinesLogicLayer.StudentBLL.insertStudent(student);

            //Es para validar si ocurrio algun error
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("El registro ha sido creado correctamente");

                //Precargando la informacion del grid por medio de la BD
                gvstudent.DataSource = ContosoUniversity.BussinesLogicLayer.StudentBLL.getAllStudents();*/
            }
    }
}
