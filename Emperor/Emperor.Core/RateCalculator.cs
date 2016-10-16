using Emperor.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core
{
    public class RateCalculator
    {
        public long GetConsumedFood(long citizens, Rate foodRate)
        {
            double multiplicator = foodRate == Rate.None ? 0 : ((int)foodRate + 1) * 0.2;
            double foodNeeded = citizens * multiplicator;
            return Convert.ToInt64(foodNeeded);

            //switch (foodRate)
            //{
            //    case Rate.None:               
            //        multiplicator = 0;
            //        break;                
            //    case Rate.VeryLow:           
            //        multiplicator = 0.4;
            //        break;               
            //    case Rate.Low:               
            //        multiplicator = 0.6;
            //        break;       
            //    case Rate.BelowAverage:
            //        multiplicator = 0.8;
            //        break;
            //    case Rate.Average:
            //        multiplicator = 1;
            //        break;
            //    case Rate.AboveAverage:
            //        multiplicator = 1.2;
            //        break;
            //    case Rate.High:
            //        multiplicator = 1.4;
            //        break;
            //    case Rate.VeryHigh:
            //        multiplicator = 1.6;
            //        break;
            //    default:
            //        multiplicator = 1.0;
            //        break;
            //}


        }

        public long GetTaxes(long citizens, Rate taxRate)
        {
            double multiplicator = taxRate == Rate.None ? 0 : ((int)taxRate + 1) * 0.2;
            double taxesPayed = citizens * multiplicator;
            return Convert.ToInt64(taxesPayed);
        }
    }
}