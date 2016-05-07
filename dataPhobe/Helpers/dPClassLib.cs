using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

namespace dataPhobe.Helpers
{
    public class dPEngine
    {

        public DataTable getCompIntWithContributionsLedger(double monthlyPmt, double princBalance, double intRate, int contribInterval, int compoundInterval, int investmentDuration)
        {
            double P = princBalance;
            double r = intRate;
            int n = compoundInterval;
            int t = investmentDuration;
            int k = contribInterval;
            double pmt = monthlyPmt;

            DataTable dt = new DataTable();
            dt.Columns.Add("YearNum");
            dt.Columns.Add("Balance");


            for (int i = 1; i <= t; i++)
            {
                DataRow legerRow = dt.NewRow();
                double balanceAsOf = getCompIntWithContributions(pmt, P, r, k, n, i);

                legerRow[0] = i;
                legerRow[1] = balanceAsOf;

                dt.Rows.Add(legerRow);

            }

            return dt;

        }

        public double getCompIntWithContributions(double monthlyPmt, double princBalance, double intRate, int contribInterval, int compoundInterval, int investmentDuration)
        {

            double P = princBalance;
            double r = intRate;
            int n = compoundInterval;
            int t = investmentDuration;
            int k = contribInterval;
            double pmt = monthlyPmt;


            double A = getCompPrincipal(P, r, n, t) + getFVSeries(pmt, r, k, t);

            return A;

        }

        public double getCompPrincipal(double princBalance, double intRate, int compoundInterval, int investmentDuration)
        {
	    // Global Viarible Declaration
            double P = princBalance;
            double r = intRate;
            int n = compoundInterval;
            int t = investmentDuration;

            double rn = r / n;
            double rn1 = rn + 1;
            double nt = n * t;
            double rnn = Math.Pow(rn1, nt);
            double A = P * rnn;
            return A;
        }

        private double getFVSeries(double monthlyPmt, double intRate, int contribInterval, int investmentDuration)
        {

            double pmt = monthlyPmt;
            double r = intRate;
            int n = contribInterval;
            int t = investmentDuration;

            //get future value of series 
            double nt = n * t;
            double rn = r / n;
            double rn1 = rn + 1;
            double rn1nt = Math.Pow(rn1, nt);
            double rnnt = rn1nt - 1;
            double a = rnnt / rn;
            double A = pmt * a;

            return A;
        }


    }
}
