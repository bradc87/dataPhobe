using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataPhobe.Helpers
{
    public class dPEngine
    {
      public double getCompIntAnnual(double princBalance, double intRate, int compoundInterval, int investmentDuration)
        {
	    // Global Viarible Declaration
            double P = princBalance;
            double r = intRate;
            int n = compoundInterval;
            int t = investmentDuration;

            double rn = r / n + 1;
            double nt = n * t;
            double rnn = Math.Pow(rn, nt);
            double A = P * rnn;
            return A;
        }


    }
}
