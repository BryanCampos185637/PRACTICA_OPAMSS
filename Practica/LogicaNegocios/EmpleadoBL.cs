using Modelo.ViewModel;
using System.Collections.Generic;
using LogicaAccesoDatos;
using Modelo;
using System;

namespace LogicaNegocios
{
    public class EmpleadoBL
    {
       public IEnumerable<EmpleadoVM>ListarEmpleados(string Filtro)
        {
            return new EmpleadoDAL().ListarEmpleado(Filtro == null ? "" : Filtro);
        }
        public string Guardar(Empleado empleado)
        {
            return new EmpleadoDAL().Guardar(empleado);
        }
        public string Modificar(Empleado empleado)
        {
            return new EmpleadoDAL().Modificar(empleado);
        }
        public string Eliminar(Int64 id)
        {
            return new EmpleadoDAL().Eliminar(id);
        }
        public Empleado EmpleadoPorId(Int64 id)
        {
            return new EmpleadoDAL().EmpleadoPorId(id);
        }
    }
}
