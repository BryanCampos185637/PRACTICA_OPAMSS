using Modelo;
using LogicaNegocios;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CargoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Cargo> Get()
        {
            return new CargoBL().ListarCargos();
        }
    }
}
