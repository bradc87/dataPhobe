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

            dataPhobe.Helpers.dPEngine engine = new Helpers.dPEngine();
            DataTable dt = engine.getCompIntWithContributionsLedger(contribAmt, princBalance, intRate, compoundInterval,compoundInterval,investmentDuration);
            DataTable dTab = new DataTable();
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