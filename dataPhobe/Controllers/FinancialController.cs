using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataPhobe.Controllers
{
    public class FinancialController : Controller
    {
        // GET: Financial
        public ActionResult CompInterest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompInterest(double princBalance, double intRate, int compoundInterval, int investmentDuration)
        {

            dataPhobe.Helpers.dPEngine engine = new Helpers.dPEngine();
            double compInterestResult = engine.getCompIntAnnual(princBalance, intRate, compoundInterval, investmentDuration);
            ViewBag.CIResult = compInterestResult.ToString();
            return View();
        }
    }
}