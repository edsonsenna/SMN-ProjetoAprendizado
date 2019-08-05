﻿using BNK.Web.Application.Operacoes;
using BNK.Web.Application.Operacoes.Model;
using System.Collections.Generic;
using System.Net.Http;
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
            HttpResponseMessage response = _operacaoApplication.GetOperacoes(1);
            

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