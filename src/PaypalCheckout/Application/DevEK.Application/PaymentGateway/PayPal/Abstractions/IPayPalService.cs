using System;
namespace DevEK.Application.PaymentGateway.PayPal.Abstractions
{
	public interface IPayPalService
	{
		Task Process();
	}
}

