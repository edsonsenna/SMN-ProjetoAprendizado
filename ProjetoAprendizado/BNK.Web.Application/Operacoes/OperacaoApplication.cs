using BNK.Web.Application.Operacoes.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace BNK.Web.Application.Operacoes
{
    public class OperacaoApplication
    {
        public HttpClient client = new HttpClient();

        public HttpResponseMessage GetOperacoes(int id)
        {
            
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri("http://localhost:14788/api/");

            var res = client.GetAsync("Operacao/Get/"+id).Result;

            return res;

        }

        public HttpResponseMessage InsOperacao(byte Cod_TipoOperacao, int Num_SeqlContaOrigem, int Num_SeqlContaDestino, int Num_ValorOperacao)
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri("http://localhost:14788/api/");

            var response =  client.PostAsync("Operacao/Post", new OperacaoModel
            {
                Cod_TipoOperacao = Cod_TipoOperacao,
                Num_SeqlContaOrigem = Num_SeqlContaOrigem,
                Num_SeqlContaDestino = Num_SeqlContaDestino,
                Num_ValorOperacao = Num_ValorOperacao

            }, new JsonMediaTypeFormatter
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
