using BNK.Domain.Usuarios;
using BNK.Domain.Usuarios.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuariosRepository _usuarioRepository;

        public UsuarioController(IUsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        [ActionName("Acesso")]
        public IHttpActionResult Acesso(UsuarioDto usuario)
        {
            var response = _usuarioRepository.Acesso(usuario);

            if (response == null)
            {
                return BadRequest("Não foi possível realizar o login!");
            }

            return Ok(response);

        }
    }
}
