using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_de_Usuarios
{
    internal class Usuarios
    {
        public int Id { get;  set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Boolean Activo { get; set; }

       
    }
}
