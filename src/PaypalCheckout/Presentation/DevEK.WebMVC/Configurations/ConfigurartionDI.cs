using System;
using DevEK.Application.PaymentGateway.PayPal;
using DevEK.Application.PaymentGateway.PayPal.Abstractions;
using DevEK.Infrastructure.PaymentGateway.PayPal;
using Microsoft.Extensions.Options;

namespace DevEK.WebMVC.Configurations
{
	public static class ConfigurartionDI
	{
		public static WebApplicationBuilder SetupDI(this WebApplicationBuilder webApplicationBuilder)
		{

			var config = webApplicationBuilder.Configuration;

			webApplicationBuilder.Services.Configure<PayPalSettings>(config.GetSection(nameof(PayPalSettings)))
				.AddSingleton(sp => sp.GetRequiredService<IOptions<PayPalSettings>>().Value);

			webApplicationBuilder.Services.AddSingleton<IPayPalAuthentication, PayPalAuthentication>();
			webApplicationBuilder.Services.AddSingleton<IPayPalService, PayPalService>();

			return webApplicationBuilder;
		}
    }
}

