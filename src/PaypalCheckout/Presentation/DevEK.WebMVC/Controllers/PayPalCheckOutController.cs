using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEK.Application.PaymentGateway.PayPal.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevEK.WebMVC.Controllers
{
    public class PayPalCheckOutController : Controller
    {
        private readonly IPayPalService _payPalService;

        public PayPalCheckOutController(IPayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            // ViewBag.ClientId is used to get the Paypal Checkout javascript SDK
            ViewBag.ClientId = _payPalService.GetClientPayPayId();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "100.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _payPalService.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _payPalService.CaptureOrder(orderId);

                var reference = response.PurchaseUnits[0].ReferenceId;

                // Put your logic to save the transaction here
                // You can use the "reference" variable as a transaction key

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}

