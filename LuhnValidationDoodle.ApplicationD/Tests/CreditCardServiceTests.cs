using LuhnValidationDoodle.DataAccess.Repo;
using LuhnValidationDoodle.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LuhnValidationDoodle.ApplicationD.Tests
{
    public class CreditCardServiceTests
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardServiceTests()
        {
            _creditCardService = new CreditCardService();
        }

        [Theory]
        [InlineData("1234567812345672", false)]
        [InlineData("1234567812345678", false)]
        [InlineData("4532015112830366", true)]
        [InlineData("6011514433546201", true)]
        public void IsValidCreditCard_ReturnExpectedResult(string creditCardNumber, bool expected)
        {
            var result = _creditCardService.IsValidCreditCard(creditCardNumber);
            Assert.Equal(expected, result);
        }
    }
}
