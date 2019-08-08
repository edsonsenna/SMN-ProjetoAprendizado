using BNK.Web.Application.Usuarios;
using BNK.Web.Application.Usuarios.Model;
using System.Net.Http;
using System.Web.Mvc;

namespace BNK.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioApplication _usuarioApplication;

        public UsuarioController(UsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }
      
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Acesso(string Nom_NomeUsuar, string Nom_SenhaUsuar)
        {
            UsuarioModel usuario = new UsuarioModel()
            {
                Nom_NomeUsuar = Nom_NomeUsuar,
                Nom_SenhaUsuar = Nom_SenhaUsuar
            };

            HttpResponseMessage response = _usuarioApplication.GetAcesso(usuario);

            if (!response.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(response.Content.ReadAsStringAsync().Result);

            }
            Response.StatusCode = 200;
            UsuarioModel usr = response.Content.ReadAsAsync<UsuarioModel>().Result;

            return RedirectToAction("GetOperacoes", "Conta", new { Num_SeqlConta = 1 });
        }

        
    }
}
