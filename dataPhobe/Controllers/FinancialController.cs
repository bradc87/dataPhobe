using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using System.Text;

namespace dataPhobe.Controllers
{
    public class FinancialController : Controller
    {
        // GET: Financial
        public ActionResult CompInterest()
        {

            Models.FinancialModel fM = new Models.FinancialModel();
            return View();
        }

        [HttpPost]
        public ActionResult CompInterest(double princBalance, double intRate, int compoundInterval, int investmentDuration, double contribAmt)
        {
            double decimalIntRate;
            decimalIntRate = intRate / 100;
            dataPhobe.Helpers.dPEngine engine = new Helpers.dPEngine();
            DataTable dt = engine.getCompIntWithContributionsLedger(contribAmt, princBalance, decimalIntRate, 12,compoundInterval,investmentDuration);
            Double investmentTotal = engine.getCompIntWithContributions(contribAmt, princBalance, decimalIntRate, 12, compoundInterval, investmentDuration);
            //DataTable dTab = new DataTable();
            ViewBag.summaryText = string.Format ("With a principal balance of <b> {0} </b> and monthly contributions of <b>{1}</b> at an interest rate of <b>{2}%</b> your balance would be <b>{3}</b>", princBalance, contribAmt, intRate, investmentTotal);
            ViewBag.chartData = genData(dt);
            return View();
        }

        public string genData(DataTable dt)
        {
            Boolean addComma = false;
            System.Text.StringBuilder sB = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dRow in dt.Rows)
                {
                    if (addComma == true) { sB.Append(", "); }
                    sB.Append("[");
                    sB.Append(dRow[0]);
                    sB.Append(", ");
                    sB.Append(dRow[1]);
                    sB.Append("]");
                    addComma = true;
                }
            }

            return sB.ToString();

        }
    }
}