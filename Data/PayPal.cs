using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayPal.Api;

namespace blazor_paypal.Data
{
    public class Token
    {
        public string GetToken()
        {


            var clientId = "AYZs-UcvaJb4y8VnNVIde-SlO5tiWNuFxDCzt22taQQRURSUxYmJtJUqegDaWqb-XuiO88H0KrVRAeug";
            var clientSecret = "ECoQbAdBUWfkBEDvi1XE-A8W0IQSi-p4RSpCJYEqmhu4aXME5oKzG5Qml1CsbYrFpmrlMEQVR2JfBWSv";

            var sdkConfig = new Dictionary<string, string> { { "mode", "sandbox" }, { "clientId", clientId }, { "clientSecret", clientSecret } };

            var accessToken = new OAuthTokenCredential(clientId, clientSecret, sdkConfig).GetAccessToken();

            var apiContext = new APIContext(accessToken);
            apiContext.Config = sdkConfig;

            return accessToken;
        }
    }

    public static class Paypal
    {

        public static async Task<RootSubscriber> GetAssinatura(string id)
        {
            Token t = new Token();

            var url = "https://api-m.sandbox.paypal.com/v1/billing/subscriptions/" + id;

            HttpClient cliente = new HttpClient();

            cliente.DefaultRequestHeaders.Add("Authorization", t.GetToken());
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cliente.DefaultRequestHeaders.Add("Accept-Language", "en_US");

            var resultado = await cliente.GetStringAsync(url);

            var r = JsonSerializer.Deserialize<RootSubscriber>(json: resultado);

            return r;
        }

        public static async Task CancelarAssinatura(string id)
        {
            Token t = new Token();

            var url = "https://api-m.sandbox.paypal.com/v1/billing/subscriptions/" + id + "/cancel";

            HttpClient cliente = new HttpClient();

            cliente.DefaultRequestHeaders.Add("Authorization", t.GetToken());
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cliente.DefaultRequestHeaders.Add("Accept-Language", "en_US");

            string j = "";

            var stringContent = new StringContent(j, UnicodeEncoding.UTF8, "application/json");

            var resultado = await cliente.PostAsync(url, stringContent);

            System.Console.WriteLine("CancelarAssinatura = " + resultado.StatusCode);
        }
    }
}