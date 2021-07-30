using Modelo;
using System.Collections.Generic;
using LogicaAccesoDatos;

namespace LogicaNegocios
{
    public class CargoBL
    {

        public IEnumerable<Cargo> ListarCargos()
        {
            return new CargoDAL().ListarCargos();
        }
    }
}
