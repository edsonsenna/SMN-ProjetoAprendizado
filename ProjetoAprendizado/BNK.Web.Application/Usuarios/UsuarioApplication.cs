using BNK.Web.Application.Usuarios.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace BNK.Web.Application.Usuarios
{
    public class UsuarioApplication
    {

        public HttpClient client = new HttpClient();

        public HttpResponseMessage GetAcesso(UsuarioModel usuario)
        {

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri("http://localhost:14788/api/");

            var response = client.PostAsync("Usuario/Acesso", usuario, new JsonMediaTypeFormatter
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
