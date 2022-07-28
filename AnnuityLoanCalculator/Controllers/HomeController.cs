using AnnuityLoanCalculator.Manager;
using AnnuityLoanCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnnuityLoanCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculationModel { });
        }

        public IActionResult Result(CalculationModel model)
        {
            if (!ModelState.IsValid || 
                (model.CalculationType == CalculationType.Days && model.PaymentStep <= 0))
            {
                return View("Index", model);
            }

            return View(Calculation.GetTableResults(model));
        }
    }
}
