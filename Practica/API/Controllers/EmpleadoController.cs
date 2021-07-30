using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using LogicaNegocios;
using Modelo;
using Modelo.ViewModel;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers:"*",methods:"*")]
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        public IEnumerable<EmpleadoVM> Get(string Filtro)
        {
            return new EmpleadoBL().ListarEmpleados(Filtro);
        }
        [HttpPost]
        public IHttpActionResult guardar([FromBody] Empleado empleado)
        {
            return Ok(new EmpleadoBL().Guardar(empleado));
        }
        [HttpPut]
        public IHttpActionResult Modificar([FromBody] Empleado empleado)
        {
            return Ok(new EmpleadoBL().Modificar(empleado));
        }
       // [Route("empleado/eliminar/{id}")]
        [HttpDelete]
        public IHttpActionResult Eliminar(Int64 id)
        {
            if (new EmpleadoBL().Eliminar(id) == "Ok")
                return Ok("ok");
            else
                return BadRequest();
        }
        [HttpGet]
        [Route("api/DetalleEmpleado")]
        public Empleado ObtenerPorId(Int64 id)
        {
            return new EmpleadoBL().EmpleadoPorId(id);
        }
    }
}
