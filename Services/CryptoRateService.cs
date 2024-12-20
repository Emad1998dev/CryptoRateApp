using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CryptoRateApp.Services
{
    public class CryptoRateService
    {
        private readonly HttpClient _httpClient;

        public CryptoRateService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Dictionary<string, decimal>> GetCryptoRatesAsync(string cryptoCode)
        {
            var apiKey = "your api key"; // کلید API
            var symbols = new[] { "USD", "EUR", "GBP", "BRL", "AUD" };
            var rates = new Dictionary<string, decimal>();

            foreach (var symbol in symbols)
            {
                var url = $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol={cryptoCode}&convert={symbol}";
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", apiKey);
                _httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JObject.Parse(responseBody);

                var price = jsonResponse["data"]?[cryptoCode.ToUpper()]?["quote"]?[symbol]?["price"];
                if (price != null)
                {
                    rates[symbol] = (decimal)price;
                }
            }

            return rates;
        }
    }
}
