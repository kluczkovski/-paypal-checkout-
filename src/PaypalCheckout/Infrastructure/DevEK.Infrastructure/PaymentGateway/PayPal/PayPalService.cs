using System;
using DevEK.Application.PaymentGateway.PayPal.Abstractions;

namespace DevEK.Infrastructure.PaymentGateway.PayPal
{
	public class PayPalService : IPayPalService
	{
		private readonly IPayPalAuthentication _payPalAuthentication;

		public PayPalService(IPayPalAuthentication payPalAuthentication)
		{
			_payPalAuthentication = payPalAuthentication;
		}

        public async Task Process()
        {
			var auth = await _payPalAuthentication.Authenticate();

        }
    }
}

