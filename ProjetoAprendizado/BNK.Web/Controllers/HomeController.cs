using BNK.Web.Application.Operacoes;
using System.Web.Mvc;

namespace BNK.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly OperacaoApplication _operacaoApplication;

        public HomeController(OperacaoApplication operacaoApplication)
        {
            _operacaoApplication = operacaoApplication;
        }

        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Index", "Conta", new { area = "" });
        }

        
    }
}