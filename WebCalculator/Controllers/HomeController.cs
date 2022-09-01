using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebCalculator.Models;
using Calculator;
using RepositoryDb;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringCalculator _calculator;

        public HomeController(ILogger<HomeController> logger, IStringCalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            var history = _calculator.ReadCalculationHistory(10);

            CalculatorModel calculatorModel = new CalculatorModel
            {
                Expression = "",
                History = history,
                IsOnlyInteger = false
            };

            return View(calculatorModel);
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

        [HttpPost]
        public IActionResult Calculate(string expression, bool isIntegerOnly)
        {

            string result;
            List<string> history = new List<string>();
            try
            {
                result = _calculator.Calculate(expression, isIntegerOnly);
                history = _calculator.ReadCalculationHistory(10);
            }
            catch (Exception e)
            {
                result = e.Message + e.InnerException?.Message;
            }

            return Json(new
            {
                success = true,
                response = result,
                history = history

            });
        }
    }
}
