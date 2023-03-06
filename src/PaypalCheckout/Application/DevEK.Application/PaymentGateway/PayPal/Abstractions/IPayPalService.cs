using System;
using DevEK.Application.PaymentGateway.PayPal.Models.Response;

namespace DevEK.Application.PaymentGateway.PayPal.Abstractions
{
	public interface IPayPalService
	{
		Task<PayPalCreateOrderResponse> CreateOrder(string value, string currency, string reference);

		Task<PayPalCaptureOrderResponse> CaptureOrder(string orderId);

		string GetClientPayPayId();
	}
}

