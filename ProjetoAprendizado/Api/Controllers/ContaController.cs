using BNK.Domain.Contas;
using System.Web.Http;

namespace Api.Controllers
{
    public class ContaController : ApiController
    {

        private readonly IContasRepository _contaRepository;

        public ContaController(IContasRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        // GET: Conta
        public IHttpActionResult Get()
        {
            return Ok(_contaRepository.Operacoes(1));
        }

        // GET: Conta/1
        [HttpGet]
        public IHttpActionResult GetOperacoes(int id)
        {
            return Ok(_contaRepository.Operacoes(id));
        }

        [HttpGet]
        public IHttpActionResult GetInfo(int id)
        {
            return Ok(_contaRepository.InfoConta(id));
        }

        // GET: Conta/Details/5
        [HttpGet]
        public IHttpActionResult Details(string id)
        {
            return Ok(_contaRepository.Operacoes(1));
        }
        

        // POST: Conta/Create
        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult CreateConfirmed()
        {
            try
            {
                // TODO: Add insert logic here

                return Ok();
            }
            catch
            {
                return Ok();
            }
        }
        

        // POST: Conta/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        public IHttpActionResult EditConfirmed(int id)
        {
            try
            {
                // TODO: Add update logic here

                return Ok();
            }
            catch
            {
                return Ok();
            }
        }

        // POST: Conta/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public IHttpActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return Ok();
            }
            catch
            {
                return Ok();
            }
        }
    }
}
