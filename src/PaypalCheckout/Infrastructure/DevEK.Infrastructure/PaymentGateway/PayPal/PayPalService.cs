using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using DevEK.Application.PaymentGateway.PayPal;
using DevEK.Application.PaymentGateway.PayPal.Abstractions;
using DevEK.Application.PaymentGateway.PayPal.Models;
using DevEK.Application.PaymentGateway.PayPal.Models.Response;

namespace DevEK.Infrastructure.PaymentGateway.PayPal
{
	public class PayPalService : IPayPalService
    {
        private const string CREATE_ORDER_ENDPOINT = "/v2/checkout/orders";
        private const string CAPTURE_ORDER_ENDPOINT = "/v2/checkout/orders/{id}/capture";

        private readonly IPayPalAuthentication _payPalAuthentication;
        private readonly HttpClient _httpClient;
        private readonly PayPalSettings _payPalSetting;


        public PayPalService(IPayPalAuthentication payPalAuthentication, HttpClient httpClient, PayPalSettings payPalSettings)
		{
			_payPalAuthentication = payPalAuthentication;
            _httpClient = httpClient;
            _payPalSetting = payPalSettings;
		}
       
        public async Task<PayPalCreateOrderResponse> CreateOrder(string value, string currency, string reference)
        {
            var requestMessage = await this.CreateHttpRequestMessage();

            if (requestMessage == null)
            {
                return null;
            }

            requestMessage.RequestUri = new Uri(_payPalSetting.BaseUrl + CREATE_ORDER_ENDPOINT);

            var payPalOrderRequest = this.PayPalCreateOrderRequest(reference, currency, value);

            requestMessage.Content = JsonContent.Create(payPalOrderRequest);

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            if (httpResponse.StatusCode != System.Net.HttpStatusCode.Created)
            {
                return null;
            }

            var jsonResponse = await httpResponse.Content.ReadAsStreamAsync();

            var response = JsonSerializer.Deserialize<PayPalCreateOrderResponse>(jsonResponse);

            return response;
        }

        public async Task<PayPalCaptureOrderResponse> CaptureOrder(string orderId)
        {
            var httpRequestMessage = await this.CreateHttpRequestMessage();

            var uri =  _payPalSetting.BaseUrl + CAPTURE_ORDER_ENDPOINT;
            uri = uri.Replace("{id}", orderId);

            httpRequestMessage.RequestUri = new Uri(uri);

            httpRequestMessage.Content = new StringContent("", Encoding.Default, "application/json");

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonResponse = await httpResponse.Content.ReadAsStreamAsync();

            var response = JsonSerializer.Deserialize<PayPalCaptureOrderResponse>(jsonResponse);

            return response;
        }

        public async Task<HttpRequestMessage> CreateHttpRequestMessage()
        {
            var auth = await _payPalAuthentication.Authenticate();

            var httpRequestMessage = new HttpRequestMessage();
            if (auth != null)
            {
                httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(), $"Bearer {auth.AccessToken}");
                httpRequestMessage.Headers.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
                httpRequestMessage.Method = HttpMethod.Post;
            }

            return httpRequestMessage;
        }

        public string GetClientPayPayId()
        {
            return _payPalSetting.ClientId;
        }

        private PayPalCreateOrder PayPalCreateOrderRequest(string reference, string currency, string value)
        {
            return new PayPalCreateOrder
            {
                Intent = "CAPTURE",
                PurchaseUnits = new List<PayPalPurchaseUnit>()
                {
                    new PayPalPurchaseUnit
                    {
                        ReferenceId = reference,
                        Amount = new PayPalAmount
                        {
                            CurrencyCode = currency,
                            Value = value
                        }
                    }
                }
            };
        }
    }
}

