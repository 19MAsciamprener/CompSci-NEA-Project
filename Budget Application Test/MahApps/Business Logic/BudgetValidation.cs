using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahApps.Business_Logic
{
    public static class BudgetValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns>Returns an empty string if no error. if errors present, return string of those errors</returns>
        public static string ValidateBudget(string Budget, DateTime? StartDate, DateTime? EndDate)
        {
            string Errors = "";


            if (Budget == "")
            {
                Errors += "|No Budget Given|\n";
            }


            double val;

            bool isNUm = double.TryParse(Budget, out val);

            if (isNUm == false)
            {
                Errors += "|Budget Amount Invalid|\n";
            }


            if (StartDate == null || EndDate == null)
            {
                Errors += "|Invalid Date(s)|\n";
            }


            else if (StartDate > EndDate)
            {
                Errors += "|Start Date Is After End Date|\n";
            }

            else if (StartDate == EndDate)
            {
                Errors += "|Start Date Is Equal To End Date|\n";
            }


            return Errors;
        }
    }
}
