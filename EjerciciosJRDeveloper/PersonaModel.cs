using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosJRDeveloper
{
    public class PersonaModel
    {
        public int IdRegistro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
