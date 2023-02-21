using System;
namespace DevEK.Application.PaymentGateway.PayPal
{
	public class AuthenticationResponse
	{
		public string Scope { get; set; }

		public string TokenType { get; set; }

		public string AppId { get; set; }

		public string ExpireIn { get; set; }

		public string Nonce { get; set; }
	}
}

