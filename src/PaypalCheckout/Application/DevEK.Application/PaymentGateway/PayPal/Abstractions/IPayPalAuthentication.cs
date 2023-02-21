using System;
namespace DevEK.Application.PaymentGateway.PayPal.Abstractions
{
	public interface IPayPalAuthentication
	{
		Task<AuthenticationResponse> Authenticate();
    }
}

