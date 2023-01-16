using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_de_Usuarios
{
    internal class conexionmysql : Conexion
    {
        private MySqlConnection connection;
        private string cadenaConexion;
        public conexionmysql() 
        {
            cadenaConexion = "Database=" + database +
                "; DataSource=" + server +
                "; User Id=" + user +
                "; Password=" + password +
                "; convert zero datetime=True";

            connection = new MySqlConnection(cadenaConexion);
        
        
        }

        public MySqlConnection  GetConnection()
        {
            try 
            { 
                if (connection.State != System.Data.ConnectionState.Open) 
                {
                    connection.Open();
                
                }
            
            }
            catch (Exception ex) 
            {
            
                MessageBox.Show(ex.ToString());
            
            
            }
            return connection;
            
            
            
            



        }

    }
}
