using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using blazor_paypal.Model;

namespace blazor_paypal.Data
{
    public class TokenData
    {
        public static async Task<string> GetTokenAsync()
        {
            var url = "https://api-m.sandbox.paypal.com/v1/oauth2/token";

            HttpClient cliente = new HttpClient();

            //Set Basic Auth
            var clientId = "AYZs-UcvaJb4y8VnNVIde-SlO5tiWNuFxDCzt22taQQRURSUxYmJtJUqegDaWqb-XuiO88H0KrVRAeug";
            var clientSecret = "ECoQbAdBUWfkBEDvi1XE-A8W0IQSi-p4RSpCJYEqmhu4aXME5oKzG5Qml1CsbYrFpmrlMEQVR2JfBWSv";
            var AuthStringBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));

            var FormData = new Dictionary<string, string>()
            {
                {"grant_type", "client_credentials"}
            };

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", AuthStringBase64);

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cliente.DefaultRequestHeaders.Add("Accept-Language", "en_US");

            var resultado = await cliente.PostAsync(url, new FormUrlEncodedContent(FormData));

            var data = JsonSerializer.Deserialize<Token>(await resultado.Content.ReadAsStringAsync());

            return data.AccessToken;
        }
    }

    public static class Paypal
    {

        public static async Task<RootSubscriber> GetAssinatura(string id)
        {
            var url = "https://api-m.sandbox.paypal.com/v1/billing/subscriptions/" + id;

            HttpClient cliente = new HttpClient();

            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + await TokenData.GetTokenAsync());
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cliente.DefaultRequestHeaders.Add("Accept-Language", "en_US");

            var resultado = await cliente.GetStringAsync(url);

            var r = JsonSerializer.Deserialize<RootSubscriber>(json: resultado);

            return r;
        }

        public static async Task CancelarAssinatura(string id)
        {
            var url = "https://api-m.sandbox.paypal.com/v1/billing/subscriptions/" + id + "/cancel";

            HttpClient cliente = new HttpClient();

            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + await TokenData.GetTokenAsync());
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cliente.DefaultRequestHeaders.Add("Accept-Language", "en_US");

            var stringContent = new StringContent("", UnicodeEncoding.UTF8, "application/json");

            var resultado = await cliente.PostAsync(url, stringContent);
        }
    }
}