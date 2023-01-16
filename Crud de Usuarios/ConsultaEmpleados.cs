using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Crud_de_Usuarios
{
    public partial class ConsultaEmpleados : Form
    {
        private List<Usuarios> musuarios;
        private consultausuarios consultausuarios;
        public ConsultaEmpleados()
        {
            InitializeComponent();

            musuarios = new List<Usuarios>();
            consultausuarios= new consultausuarios();

            cargarusuarios();

        }

        private void cargarusuarios(String filtro = "")
        {
           dgvbusqueda.Rows.Clear();
            dgvbusqueda.Refresh();
            musuarios.Clear();
            musuarios = consultausuarios.getusuarios(filtro);
            
            for (int i=0;i<musuarios.Count();i ++)
            {
                dgvbusqueda.RowTemplate.Height = 50;
                dgvbusqueda.Rows.Add(
                    musuarios[i].Id,
                    musuarios[i].Nombre,
                    musuarios[i].FechaNacimiento.ToString("dd/MM/yyyy"),
                    musuarios[i].Direccion,
                    musuarios[i].Telefono,
                    musuarios[i].Activo

                    );
            }


        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarusuarios(txtbusqueda.Text.Trim());
        }
    }
}
