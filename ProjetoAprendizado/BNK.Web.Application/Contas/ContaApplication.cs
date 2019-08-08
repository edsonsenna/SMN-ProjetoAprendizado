using BNK.Web.Application.Contas.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
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

            var res = client.GetAsync("Conta/GetOperacoes/" + id).Result;

            return res;

        }


        public HttpResponseMessage GetInfo(int id)
        {

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri("http://localhost:14788/api/");

            var res = client.GetAsync("Conta/GetInfo/" + id).Result;

            return res;

        }

        public HttpResponseMessage AttConta(ContaModel conta)
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri("http://localhost:14788/api/");

            var response = client.PostAsync("Conta/Edit", conta, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return response;

        }



    }
}
