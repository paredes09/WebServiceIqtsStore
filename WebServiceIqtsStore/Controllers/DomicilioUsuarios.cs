using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebServiceIqtsStore.Entities;

namespace WebServiceIqtsStore.Controllers
{
    [ApiController]
    [Route("api/DomicilioUsuarios")]
    public class DomicilioUsuarios : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DomicilioUsuarios(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("allDomicilios")]
        public async Task<ActionResult> getDomicilios()
        {
            var domicilios = await context.domicilioUsuario.FromSqlRaw("SELECT * FROM domicilioUsuario").ToListAsync();
            return Ok(domicilios);
        }

        [HttpPost]
        [Route("crearDomicilio")]
        public async Task<ActionResult> postDomicilio([FromBody] domicilioUsuario domicilioUsuarios)
        {
            try
            {
                var domicilio = await context.Database.ExecuteSqlRawAsync("EXEC REGISTRAR_DOMICILIO @nombreDireccion,@pisoDepartamentoDireccion,@referencia,@nombreDepartamento,@nombreProvincia,@nombreDistrito,@idUsuario",
                new SqlParameter("@nombreDireccion", domicilioUsuarios.nombreDireccion),
                new SqlParameter("@pisoDepartamentoDireccion", domicilioUsuarios.pisoDepartamentoDireccion),
                new SqlParameter("@referencia", domicilioUsuarios.referencia),
                new SqlParameter("@nombreDepartamento", domicilioUsuarios.nombreDepartamento),
                new SqlParameter("@nombreProvincia", domicilioUsuarios.nombreProvincia),
                new SqlParameter("@nombreDistrito", domicilioUsuarios.nombreDistrito),
                new SqlParameter("@idUsuario", domicilioUsuarios.idUsuario));
                return Ok(domicilio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizarDomicilio")]
        public async Task<ActionResult> putDomicilio([FromBody] domicilioUsuario domicilioUsuarios)
        {
            try
            {
                var domicilio = await context.Database.ExecuteSqlRawAsync("EXEC ACTUALIZAR_DOMICILIO @nombreDireccion,@pisoDepartamentoDireccion,@referencia,@nombreDepartamento,@nombreProvincia,@nombreDistrito,@idUsuario",
                new SqlParameter("@nombreDireccion", domicilioUsuarios.nombreDireccion),
                new SqlParameter("@pisoDepartamentoDireccion", domicilioUsuarios.pisoDepartamentoDireccion),
                new SqlParameter("@referencia", domicilioUsuarios.referencia),
                new SqlParameter("@nombreDepartamento", domicilioUsuarios.nombreDepartamento),
                new SqlParameter("@nombreProvincia", domicilioUsuarios.nombreProvincia),
                new SqlParameter("@nombreDistrito", domicilioUsuarios.nombreDistrito),
                new SqlParameter("@idUsuario", domicilioUsuarios.idUsuario));
                return Ok(domicilio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
