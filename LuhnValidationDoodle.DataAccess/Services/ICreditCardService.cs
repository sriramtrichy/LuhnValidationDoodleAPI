using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnValidationDoodle.DataAccess.Services
{
    public interface ICreditCardService
    {
        bool IsValidCreditCard(string creditCardNumber);
    }
}
