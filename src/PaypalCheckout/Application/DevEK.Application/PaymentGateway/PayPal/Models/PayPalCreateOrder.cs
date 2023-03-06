using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalCreateOrder
	{
		[JsonPropertyName("intent")]
		public string Intent { get; set; }


        [JsonPropertyName("purchase_units")]
        public List<PayPalPurchaseUnit> PurchaseUnits { get; set; }
	}
}

