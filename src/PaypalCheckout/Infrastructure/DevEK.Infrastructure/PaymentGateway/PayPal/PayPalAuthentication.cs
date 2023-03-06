using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DevEK.Application.PaymentGateway.PayPal;
using DevEK.Application.PaymentGateway.PayPal.Abstractions;
using DevEK.Application.PaymentGateway.PayPal.Models.Response;

namespace DevEK.Infrastructure.PaymentGateway.PayPal
{
	public class PayPalAuthentication : IPayPalAuthentication
    {
        private const string ENDPOINT = "/v1/oauth2/token";
        private readonly PayPalSettings _payPalSetting;
        private readonly HttpClient _httpclient;
      
        public PayPalAuthentication(PayPalSettings payPalSetting, HttpClient httpClient)
        {
            _payPalSetting = payPalSetting;
            _httpclient = httpClient;
        }

        public async Task<PayPalAuthenticationResponse?> Authenticate()
        {
            var request = CreateHttpRequestMessage();
  
            var httpResponse = await _httpclient.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonResponse = await httpResponse.Content.ReadAsStreamAsync();

            var response = JsonSerializer.Deserialize<PayPalAuthenticationResponse>(jsonResponse);

            return response;
        }

        private HttpRequestMessage CreateHttpRequestMessage()
        {
            var content = new List<KeyValuePair<string, string>>()
            {
                new("grant_type", "client_credentials")
            };

            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_payPalSetting.ClientId}:{_payPalSetting.Secret}"));

            var requestMessage = new HttpRequestMessage();
            requestMessage.RequestUri = new Uri(_payPalSetting.BaseUrl + ENDPOINT);
            requestMessage.Method = HttpMethod.Post;
            requestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(), $"Basic {auth}");
            requestMessage.Content = new FormUrlEncodedContent(content);

            return requestMessage;
        }
    }
}

