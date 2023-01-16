using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_de_Usuarios
{
    public partial class AgregarEmpleados : Form 
    {
        private List<Usuarios> musuarios;
        private consultausuarios consultausuarios;
        private Usuarios usuario;
        public AgregarEmpleados()
        {
            InitializeComponent();
            musuarios = new List<Usuarios>();
            consultausuarios = new consultausuarios();
            usuario = new Usuarios();
            cargarusuarios();

        }

        private void cargarusuarios(String filtro = "")
        {
            dgvbusqueda.Rows.Clear();
            dgvbusqueda.Refresh();
            musuarios.Clear();
            musuarios = consultausuarios.getusuarios(filtro);

            for (int i = 0; i < musuarios.Count(); i++)
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



















        //agregar
        private bool DatosCorrectos()
        {
            if (txtnombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese El Campo Nombre");
            }

            if (txtnombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese El Campo Nombre");
                return false;
            }

            if (txttelefono .Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese El Campo Telefono");
                return false;
            }

            if (txtdireccion.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese El Campo Direccion");
                return false;
            }

            if (dtNacimiento.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese El Campo Fecha");
                return false;

            }
            //validaciones

            

            return true;
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            if (!DatosCorrectos()) 
            {
                return;

            }

            cargardatosusuario();

            if (consultausuarios.agregar(usuario)) {

                MessageBox.Show("Usuario Registrado");
                cargardatosusuario();
                limpiarcampos();


            }
            cargarusuarios();




        }

        private void limpiarcampos() 
        {
           
            txtID.Clear();
            txtnombre.Clear();
            dtNacimiento.ResetText();
            txttelefono.Clear();
            comboBox1.ResetText();
          
        
        }


        private void cargardatosusuario()
        {
            usuario.Id = ObtenerId();
            usuario.Nombre = txtnombre.Text.Trim();
            usuario.FechaNacimiento = dtNacimiento.Value;
            usuario.Direccion = txtdireccion.Text.Trim();
            usuario.Telefono = txttelefono.Text.Trim();
            if (comboBox1.SelectedItem.ToString().Equals("Activado"))
            {
                usuario.Activo = true;

            }
            else
            {
                usuario.Activo = false;
            }
            
           
           

        }


        private int ObtenerId()
        {
            if (!this.txtID.Text.Trim().Equals(""))
            {
                if (int.TryParse(this.txtID.Text.Trim(), out int id))
                {
                    return id;
                }
                else return -1;
            }
            else return -1;
        }

        //modificar celda

        private void dgvbusqueda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvbusqueda.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(fila.Cells["ID"].Value);
            txtnombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            dtNacimiento.Value= DateTime.ParseExact(fila.Cells["FechaNacimiento"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtdireccion .Text = Convert.ToString(fila.Cells["Direccion"].Value);
            txttelefono.Text = Convert.ToString(fila.Cells["Telefono"].Value);
            

             if(Convert.ToBoolean(fila.Cells["Activo"].Value) == true)
            {
                comboBox1.SelectedItem = "Activado";
            }
             else
            {
                comboBox1.SelectedItem = "Desactivado";
            }


                

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            if (!DatosCorrectos())
            {
                return;

            }

            cargardatosusuario();

            if (consultausuarios.modificarusuario(usuario))
            {

                MessageBox.Show("Informacion Actualizada");
                cargardatosusuario();
                limpiarcampos();


            }
            cargarusuarios();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(sender, e);

        }

        private void ValidarLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
