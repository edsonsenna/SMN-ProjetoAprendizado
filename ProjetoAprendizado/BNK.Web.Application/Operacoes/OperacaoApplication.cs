using System;
using System.Net.Http;

namespace BNK.Web.Application.Operacoes
{
    public class OperacaoApplication
    {
        public HttpClient client = new HttpClient();

        public HttpResponseMessage GetOperacoes(int id)
        {


            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri("http://localhost:14788/api/");

            var res = client.GetAsync("Operacao/1").Result;

            

            return res;

        }

    
    

    }
}
