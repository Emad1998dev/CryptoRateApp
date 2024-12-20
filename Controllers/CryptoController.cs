using CryptoRateApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoRateApp.Controllers
{
    public class CryptoController : Controller
    {
        private readonly CryptoRateService _cryptoRateService;

        public CryptoController()
        {
            _cryptoRateService = new CryptoRateService();
        }

        // نمایش فرم انتخاب ارز دیجیتال
        public IActionResult Index()
        {
            return View();
        }

        // نمایش نرخ تبدیل برای ارز دیجیتال انتخاب شده
        public async Task<IActionResult> Rates(string cryptoCode = "BTC")
        {
            if (string.IsNullOrEmpty(cryptoCode))
            {
                ViewBag.Error = "Please provide a valid cryptocurrency code.";
                return View("Index");
            }

            try
            {
                var rates = await _cryptoRateService.GetCryptoRatesAsync(cryptoCode);
                ViewBag.CryptoCode = cryptoCode;
                ViewBag.Rates = rates;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred while fetching the cryptocurrency rates. Please try again.";
                ViewBag.ExceptionDetails = ex.Message; // فقط برای دیباگ
                return View("Index");
            }
        }
    }
}
