using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebServiceIqtsStore.Entities;

namespace WebServiceIqtsStore.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("allUsuarios")]
        public async Task<ActionResult> getUsuarios()
        {
            var usuarios = await context.Usuarios.FromSqlRaw("SELECT * FROM USUARIO").ToListAsync();
            return Ok(usuarios);
        }
        [HttpPost]
        [Route("crearUsuario")]
        public async Task<ActionResult> crearUsuario([FromBody] Usuarios usuarios)
        {
            try {
                var usuario = await context.Database.ExecuteSqlRawAsync("EXEC REGISTRAR_USUARIO @nombre,@correo,@contraseña,@celular,@idUsuario,@estado,@tipoUsuario",
                  new SqlParameter("@nombre", usuarios.nombreApellido),
                  new SqlParameter("@correo", usuarios.correo),
                  new SqlParameter("@contraseña", usuarios.password),
                  new SqlParameter("@celular", usuarios.celular),
                  new SqlParameter("@idUsuario", usuarios.uIdUsuario),
                  new SqlParameter("@estado", usuarios.estadoUsuario),
                  new SqlParameter("@tipoUsuario", usuarios.idTipoUsuario));
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("actualizarUsuario")]
        public async Task<ActionResult> actualizarUsuario([FromBody] Usuarios usuarios)
        {
            try
            {
                var usuario = await context.Database.ExecuteSqlRawAsync("EXEC ACTUALIZAR_USUARIO @nombre,@correo,@contraseña,@celular,@idUsuario,@estado,@tipoUsuario",
                new SqlParameter("@nombre", usuarios.nombreApellido),
                new SqlParameter("@correo", usuarios.correo),
                new SqlParameter("@contraseña", usuarios.password),
                new SqlParameter("@celular", usuarios.celular),
                new SqlParameter("@idUsuario", usuarios.uIdUsuario),
                new SqlParameter("@estado", usuarios.estadoUsuario),
                new SqlParameter("@tipoUsuario", usuarios.idTipoUsuario));
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   
    }
}
