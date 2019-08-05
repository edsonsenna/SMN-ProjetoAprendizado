using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BNK.Web.Application.Contas
{
    public class ContaApplication
    {

        public HttpClient client = new HttpClient();

        public HttpResponseMessage GetOperacoes(int id)
        {

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri("http://localhost:14788/api/");

            var res = client.GetAsync("Conta/GetOperacoes/1").Result;

            return res;

        }
    }
}
