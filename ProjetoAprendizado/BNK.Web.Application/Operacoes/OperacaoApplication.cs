
using BNK.Web.Application.Operacoes.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BNK.Web.Application.Operacoes
{
    class OperacaoApplication
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(OperacaoModal operacao)
        {
            Console.WriteLine($"Name: {operacao.Cod_TipoOperacao}\tPrice: " +
                $"{operacao.Num_SeqlContaDestino}\tCategory: {operacao.Num_SeqlContaOrigem}");
        }

        static async Task<Uri> CreateProductAsync(OperacaoModal operacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/products", operacao);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<OperacaoModal> GetProductAsync(string path)
        {
            OperacaoModal operacao = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                operacao = await response.Content.ReadAsAsync<OperacaoModal>();
            }
            return operacao;
        }

        static async Task<OperacaoModal> UpdateProductAsync(OperacaoModal operacao)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{operacao.Num_SeqlOperacao}", operacao);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            operacao = await response.Content.ReadAsAsync<OperacaoModal>();
            return operacao;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                OperacaoModal operacao = new OperacaoModal
                {
                    Cod_TipoOperacao = 2,
                    Num_ValorOperacao = 100,
                    Num_SeqlContaOrigem = 1
                };

                var url = await CreateProductAsync(operacao);
                Console.WriteLine($"Created at {url}");

                // Get the product
                operacao = await GetProductAsync(url.PathAndQuery);
                ShowProduct(operacao);

                // Update the product
                Console.WriteLine("Updating price...");
                operacao.Num_ValorOperacao = 80;
                await UpdateProductAsync(operacao);

                // Get the updated product
                operacao = await GetProductAsync(url.PathAndQuery);
                ShowProduct(operacao);

                // Delete the product
                var statusCode = await DeleteProductAsync(operacao.Num_SeqlOperacao.ToString());
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }


    }
}
