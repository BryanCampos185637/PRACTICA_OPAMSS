
using System;

namespace Modelo
{
    public class Empleado
    {
        public Int64 EmpleadoId { get; set; }
        public Int64 CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }
       
    }
}
