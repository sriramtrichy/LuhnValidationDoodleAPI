using LuhnValidationDoodle.DataAccess.Repo;
using LuhnValidationDoodle.DataAccess.Services;

namespace LuhnValidationTests
{
    public class UnitTest1
    {
        private readonly ICreditCardService _creditCardService;

        public UnitTest1()
        {
            _creditCardService = new CreditCardService();
        }

        [Theory]
        [InlineData("4532015112830366", true)]
        [InlineData("6011514433546201", true)]
        [InlineData("0000123456789123", false)]
        [InlineData("1234567812345672", false)]
        public void IsValidCreditCardReturnExpectedResult(string creditCardNumber, bool expected)
        {
            var result = _creditCardService.IsValidCreditCard(creditCardNumber);
            Assert.Equal(expected, result);
        }
    }
}