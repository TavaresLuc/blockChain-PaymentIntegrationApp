using System;
using System.Net.Http;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cryptoPayment.Services
{
    public class KamoneyApi
    {
        private readonly string _baseUrl = "https://api2.kamoney.com.br/v2/private/";
        private readonly string _publicKey;
        private readonly string _secretKey;

        public KamoneyApi(string publicKey, string secretKey)
        {
            _publicKey = publicKey;
            _secretKey = secretKey;
        }

        private string GenerateSignature(string queryString)
        {
            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_secretKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(queryString));
                string sign = BitConverter.ToString(hash).Replace("-", "").ToLower();
                Console.WriteLine($"Sign: {sign}");
                Console.WriteLine("Debugging Signature:");
                Console.WriteLine($"Query String: {queryString}");
                Console.WriteLine($"Secret Key: {_secretKey}");
                Console.WriteLine($"Generated Sign: {sign}");
                return sign;

            }
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string endpoint, string queryString = "", object body = null)
        {

            var request = new HttpRequestMessage(method, _baseUrl + endpoint + "?" + queryString);

            if (body != null)
            {
                var jsonBody = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            var signature = GenerateSignature(queryString);
            request.Headers.Add("public", _publicKey);
            request.Headers.Add("sign", signature);

            return request;
        }


        public async Task<string> CreatePaymentLink(string label, double amount)
        {
            var body = new { label, amount };
            var request = CreateRequest(HttpMethod.Post, "merchant/paymentlink", "", body);

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro na API Kamoney: {response.StatusCode} - {responseContent}");
                }

                return responseContent;
            }
        }
    }
}
