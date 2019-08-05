using BNK.Domain.Contas;
using BNK.Domain.Operacoes;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class OperacaoController : ApiController
    {


        private readonly IOperacoesRepository _operacaoRepository;

        public OperacaoController(IOperacoesRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        // GET: api/Operacao
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Operacao/5
        public IHttpActionResult Get(int id)
        {
            List<OperacaoDto> operacoes = new List<OperacaoDto>();

            operacoes.Add(new OperacaoDto()
            {
                Cod_TipoOperacao = 2,
                Num_SeqlContaOrigem = 1,
                Num_ValorOperacao = 20
            });

            return Ok(operacoes);
        }

        // POST: api/Operacao
        public IHttpActionResult Post([FromBody]OperacaoDto operacao)
        {
            _operacaoRepository.Deposita(operacao);
            return BadRequest(operacao.ToString());
        }

        // PUT: api/Operacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Operacao/5
        public void Delete(int id)
        {
        }
    }
}
