using BNK.Web.Application.Contas;
using BNK.Web.Application.Operacoes.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace BNK.Web.Controllers
{
    public class ContaController : Controller
    {

        private readonly ContaApplication _contaApplication;

        public ContaController(ContaApplication contaApplication)
        {
            _contaApplication = contaApplication;
        }

        // GET: api/Conta/5
        public ActionResult Index(int id = 1)
        {
            HttpResponseMessage response = _contaApplication.GetOperacoes(1);


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

       
    }
}
