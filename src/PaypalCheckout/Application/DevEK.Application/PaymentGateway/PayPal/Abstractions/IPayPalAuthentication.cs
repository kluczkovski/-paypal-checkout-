using System;
using DevEK.Application.PaymentGateway.PayPal.Models.Response;

namespace DevEK.Application.PaymentGateway.PayPal.Abstractions
{
	public interface IPayPalAuthentication
	{
		Task<PayPalAuthenticationResponse?> Authenticate();
    }
}

