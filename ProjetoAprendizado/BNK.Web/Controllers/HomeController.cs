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

        public JsonResult Index()
        {

            return Json(_operacaoApplication.GetOperacoes(1), JsonRequestBehavior.AllowGet);
        }

        
    }
}