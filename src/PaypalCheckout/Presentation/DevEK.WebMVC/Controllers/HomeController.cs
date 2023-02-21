using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevEK.WebMVC.Models;
using DevEK.Application.PaymentGateway.PayPal.Abstractions;

namespace DevEK.WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPayPalService _payPalServices;

    public HomeController(ILogger<HomeController> logger, IPayPalService payPalService)
    {
        _logger = logger;
        _payPalServices = payPalService;
    }

    public IActionResult Index()
    {
        _payPalServices.Process();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

