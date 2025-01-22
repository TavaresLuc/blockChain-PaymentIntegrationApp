
using System.Diagnostics;

using System.Text;

using Newtonsoft.Json;
using cryptoPayment.Models;


namespace cryptoPayment.Services
{
    public class KamoneyApi
    {
        public readonly HttpClient HttpClient;

        public KamoneyApi(string bearerToken)
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api2.kamoney.com.br/v2/")
            };

            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
            HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<string> CreateMerchantSale(string asset, string network, double amount, string email)
        {
            try
            {
                // Cria o corpo da requisição
                var body = new
                {
                    asset,
                    network,
                    amount,
                    email
                };

                var jsonBody = JsonConvert.SerializeObject(body);

                // Logs para depuração
                Debug.WriteLine("Request Details:");
                Debug.WriteLine($"URI: {HttpClient.BaseAddress}private/merchant");
                Debug.WriteLine($"Headers: Authorization={HttpClient.DefaultRequestHeaders.Authorization}");
                Debug.WriteLine($"Body JSON: {jsonBody}");

                // Configura o conteúdo da requisição
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); // Configura explicitamente o Content-Type

                // Envia a requisição POST
                var response = await HttpClient.PostAsync("private/merchant", content);

                // Lê o conteúdo da resposta
                var responseContent = await response.Content.ReadAsStringAsync();

                // Logs da resposta
                Debug.WriteLine($"Response Status: {response.StatusCode}");
                Debug.WriteLine($"Response Content: {responseContent}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro na API Kamoney: {response.StatusCode} - {responseContent}");
                }

                return responseContent;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro: {ex.Message}");
                throw;
            }
        }


        public async Task<string> GetCurrenciesAsync()
        {
            try
            {
                var response = await HttpClient.GetAsync("public/currency");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao obter moedas: {ex.Message}");
                throw;
            }
        }

        public async Task<List<NetworkInfo>> GetCurrencyNetworksAsync(string asset)
        {
            try
            {
                var response = await HttpClient.GetAsync($"public/currency/{asset}");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

                if (jsonResponse.success == true)
                {
                    var networks = new List<NetworkInfo>();
                    foreach (var network in jsonResponse.data)
                    {
                        networks.Add(new NetworkInfo
                        {
                            Name = network.name,
                            Protocol = network.protocol,
                            Symbol = network.symbol,
                            Enabled = network.enabled
                        });
                    }
                    return networks;
                }

                throw new Exception($"Erro ao buscar redes: {jsonResponse.msg}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao obter redes para {asset}: {ex.Message}");
                throw;
            }
        }


    }
}