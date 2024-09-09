using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebServiceIqtsStore.Controllers
{
    [ApiController]
    [Route("api/ubicaciones")]
    public class UbicacionesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public UbicacionesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("departamentos")]
        public async Task<ActionResult> getDepartamentos()
        {
            var departamentos = await context.Departamentos.FromSqlRaw("SELECT * FROM DEPARTAMENTO").ToListAsync();
            return Ok(departamentos);
        }
        [HttpGet]
        [Route("provincias")]
        public async Task<ActionResult> getProvincias()
        {
            var provincias = await context.Provincias.FromSqlRaw("SELECT * FROM PROVINCIA").ToListAsync();
            return Ok(provincias);
        }
        [HttpGet]
        [Route("distritos")]
        public async Task<ActionResult> getDistritos()
        {
            var distritos = await context.Distritos.FromSqlRaw("SELECT * FROM DISTRITO").ToListAsync();
            return Ok(distritos);
        }


    }
}
