using System.Net.Http.Json;
using Redkik.Classes;

namespace Redkik
{
    public class API
    {

        static HttpClient? client = null;
        static Token? token = null;

        public static string BaseAddress { get { return client == null || client.BaseAddress == null ? "N/a" : client.BaseAddress.ToString(); } }

        public static void Initialize(string baseUrl)
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public static async Task<Token?> Login(string username, string password)
        {
            if (client == null)
                throw new NullReferenceException("Call Initialize function first");
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/v1/user/Users/login", new Login(username, password));
            if (response.IsSuccessStatusCode)
            {
                token = await response.Content.ReadFromJsonAsync<Token>();
                return token;
            }
            else
            {
                ServerError? error = await response.Content.ReadFromJsonAsync<ServerError>();
                throw new Exception(error?.error?.message == null ? "An unknown error occured" : error.error.message);
            }
        }

        public static async Task<List<Country>?> GetCountries()
        {
            if (client == null || token == null)
                throw new NullReferenceException("Call Initialize function first");
            return await client.GetFromJsonAsync<List<Country>>(string.Format("/api/v1/quote/Countries?access_token={0}", token.id));
        }

        public static async Task<List<Commodity>?> GetCommodities()
        {
            if (client == null || token == null)
                throw new NullReferenceException("Call Initialize function first");
            return await client.GetFromJsonAsync<List<Commodity>>(string.Format("/api/v1/quote/Commodities?access_token={0}", token.id));
        }

        public static async Task<Response<List<Offer>>?> GetOffers(QuotePayload quote)
        {
            if (client == null || token == null)
                throw new NullReferenceException("Call Initialize function first");
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("/api/v1/quote/Bookings/quote?access_token={0}", token.id), quote);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Response<List<Offer>>>();
            }
            else
            {
                ServerError? error = await response.Content.ReadFromJsonAsync<ServerError>();
                throw new Exception(error?.error?.message == null ? "An unknown error occured" : error.error.message);
            }
        }

        public static async Task<Response<Booking>?> PurchaseOffer(Offer offer)
        {
            if (client == null || token == null)
                throw new NullReferenceException("Call Initialize function first");
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("/api/v1/quote/Bookings/purchase?access_token={0}", token.id), new { offerId = offer.id });
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Response<Booking>>();
            }
            else
            {
                ServerError? error = await response.Content.ReadFromJsonAsync<ServerError>();
                throw new Exception(error?.error?.message == null ? "An unknown error occured" : error.error.message);
            }
        }
    }
}
