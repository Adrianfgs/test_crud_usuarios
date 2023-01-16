using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_de_Usuarios
{
    internal class consultausuarios
    {
        private conexionmysql conexionmysql;
        private List<Usuarios> musuarios;

        public consultausuarios()
        {
            conexionmysql = new conexionmysql();
            musuarios = new List<Usuarios>();
        }


        public List<Usuarios> getusuarios(string filtro)
        {
            string QUERY = "SELECT * FROM usuarios ";
            MySqlDataReader mreader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += " WHERE " +
                        "ID LIKE \"%" + filtro + "%\" OR " +
                        "Nombre LIKE '%" + filtro + "%' OR " +
                        "FechaNacimiento LIKE '%" + filtro + "%' OR "  +
                        "Direccion LIKE '%" + filtro + "%' OR " +
                        "Telefono LIKE '%" + filtro + "%' OR " +
                        "Activo LIKE '%" + filtro + "%'; ";

                }
                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection= conexionmysql.GetConnection(); 
                mreader= mComando.ExecuteReader();

                Usuarios musuarios = null;
                while (mreader.Read())
                {
                    musuarios = new Usuarios();
                    musuarios.Id = mreader.GetInt32("id");
                    musuarios.Nombre = mreader.GetString("Nombre");
                    musuarios.FechaNacimiento = mreader.GetDateTime("FechaNacimiento");
                    musuarios.Direccion = mreader.GetString("Direccion");
                    musuarios.Telefono = mreader.GetString("Telefono");
                    musuarios.Activo = mreader.GetBoolean("Activo");
                    this.musuarios.Add(musuarios);      

                }
                mreader.Close();

            }
            catch(Exception ex)
            {
                throw;


            }
            return musuarios;
        }

        internal bool agregar(Usuarios musuarios)
        {
            string INSERT = " INSERT INTO usuarios (Nombre, FechaNacimiento, Direccion, Telefono, Activo ) " +
                "VALUES (@Nombre, @FechaNacimiento, @Direccion, @Telefono, @Activo ) ";

            MySqlCommand cmd = new MySqlCommand(INSERT,conexionmysql.GetConnection() );
           
            cmd.Parameters.Add(new MySqlParameter("@Nombre", musuarios.Nombre));
            cmd.Parameters.Add(new MySqlParameter("@FechaNacimiento", musuarios.FechaNacimiento));
            cmd.Parameters.Add(new MySqlParameter("@Direccion", musuarios.Direccion));
            cmd.Parameters.Add(new MySqlParameter("@Telefono", musuarios.Telefono));
            cmd.Parameters.Add(new MySqlParameter("@Activo", musuarios.Activo));

            return cmd.ExecuteNonQuery() > 0; 



        }

        internal bool modificarusuario(Usuarios usuario)
        {
            string UPDATE = " UPDATE usuarios SET " +
                "Nombre=@Nombre, " +
                "FechaNacimiento=@FechaNacimiento, " +
                "Direccion=@Direccion, " +
                "Telefono=@Telefono, " +
                "Activo=@Activo " +
                "WHERE ID=@ID;";

            MySqlCommand cmd = new MySqlCommand(UPDATE, conexionmysql.GetConnection());
            cmd.Parameters.Add(new MySqlParameter("@ID", usuario.Id));
            cmd.Parameters.Add(new MySqlParameter("@Nombre", usuario.Nombre));
            cmd.Parameters.Add(new MySqlParameter("@FechaNacimiento", usuario.FechaNacimiento));
            cmd.Parameters.Add(new MySqlParameter("@Direccion", usuario.Direccion));
            cmd.Parameters.Add(new MySqlParameter("@Telefono", usuario.Telefono));
            cmd.Parameters.Add(new MySqlParameter("@Activo", usuario.Activo));

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
