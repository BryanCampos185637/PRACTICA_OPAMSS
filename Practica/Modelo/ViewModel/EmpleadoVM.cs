using System;
namespace Modelo.ViewModel
{
    public class EmpleadoVM
    {
        public Int64 EmpleadoId { get; set; }
        public Int64 CargoId { get; set; }
        public string NombreCargo { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public string FechaNacimiento { get; set; }
}
}
