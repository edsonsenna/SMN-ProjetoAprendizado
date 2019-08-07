using BNK.Web.Application.Contas;
using BNK.Web.Application.Contas.Model;
using BNK.Web.Application.Operacoes;
using BNK.Web.Application.Operacoes.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace BNK.Web.Controllers
{
    public class ContaController : Controller
    {

        private readonly ContaApplication _contaApplication;
        private readonly OperacaoApplication _operacaoApplication;

        public ContaController(ContaApplication contaApplication, OperacaoApplication operacaoApplication)
        {
            _contaApplication = contaApplication;
            _operacaoApplication = operacaoApplication;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        
        public ActionResult GetOperacoes(int Num_SeqlConta = 1)
        {
            HttpResponseMessage response = _contaApplication.GetOperacoes(Num_SeqlConta);

            if (!response.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(response.Content.ReadAsStringAsync().Result);

            }
            Response.StatusCode = 200;
            // Json(response.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);
            return View("List", response.Content.ReadAsAsync<List<OperacaoModel>>().Result);
        }
        
        public ActionResult NovaOperacao(int Num_SeqlConta = 1)
        {
            ViewBag.Num_SeqlConta = Num_SeqlConta;
            return View("NovaOperacao");
        }

        public ActionResult InfoConta(int Num_SeqlConta = 1)
        {

            HttpResponseMessage response = _contaApplication.GetInfo(Num_SeqlConta);

            if (!response.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(response.Content.ReadAsStringAsync().Result);

            }
            Response.StatusCode = 200;
            return View("Edit", response.Content.ReadAsAsync<ContaModel>().Result);
        }

        public ActionResult RealizarOperacao(byte Cod_TipoOperacao, int Num_SeqlContaOrigem, int Num_SeqlContaDestino, int Num_ValorOperacao)
        {
            _operacaoApplication.InsOperacao(Cod_TipoOperacao, Num_SeqlContaOrigem, Num_SeqlContaDestino, Num_ValorOperacao);

            return RedirectToAction("GetOperacoes", new { Num_SeqlConta = Num_SeqlContaOrigem});
        }
        

       
    }
}
