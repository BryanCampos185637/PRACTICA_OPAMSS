using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaAccesoDatos
{
    public class CargoDAL
    {
        public static string ObtenerNombreCargo(Int64 id)
        {
            using (var db = new PracticaContext())
            {
                return db.Cargo.Where(p => p.CargoId.Equals(id)).First().Nombre;
            }
        }
        public List<Cargo> ListarCargos()
        {
            using(var db = new PracticaContext())
            {
                return db.Cargo.Where(P=>P.Estado.Equals("ACT")).ToList();
            }
        }
    }
}
