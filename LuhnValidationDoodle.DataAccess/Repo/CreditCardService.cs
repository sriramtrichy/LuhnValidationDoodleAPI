using LuhnValidationDoodle.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnValidationDoodle.DataAccess.Repo
{
    public class CreditCardService : ICreditCardService
    {
        public bool IsValidCreditCard(string creditCardNumber)
        {
            //Check creditcard number having whitespace
            if (string.IsNullOrWhiteSpace(creditCardNumber))
                return false;

            int sum = 0;
            bool alternate = false;

            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                //Check any character in credit card number
                char c = creditCardNumber[i];
                if (!char.IsDigit(c))
                    return false;

                int n = c - '0';

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                        n -= 9;
                }

                sum += n;
                alternate = !alternate;
            }

            return (sum % 10 == 0);

        }
    
    }
}
