using System;
using DevEK.Application.PaymentGateway.PayPal;
using DevEK.Application.PaymentGateway.PayPal.Abstractions;

namespace DevEK.Infrastructure.PaymentGateway.PayPal
{
	public class PayPalAuthentication : IPayPalAuthentication
    {
        private readonly PayPalSettings _payPalSetting;

        public PayPalAuthentication(PayPalSettings payPalSetting)
        {
            _payPalSetting = payPalSetting;
        }


        public Task<AuthenticationResponse> Authenticate()
        {
            throw new NotImplementedException();
        }
    }
}

