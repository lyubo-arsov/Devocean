using System;
using TaxCalculator.BL.TaxRules;
using Xunit;

namespace TaxCalculator.Tests.Unit.TaxRules
{
    public class IncomeTaxTests
    {
        [Theory]
        [InlineData(100, 30, 300, 60)]
        [InlineData(0, 15, 100, 15)]
        [InlineData(100, 10, 100, 0)]
        public void GetTax_correct_values(decimal minApplyAmount, decimal percent, decimal salary, decimal expected)
        {
            var rule = new IncomeTaxRule(percent, minApplyAmount);

            var res = rule.GetTax(salary);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetTax_invalid_percent_must_throw(decimal salary)
        {
            var rule = new IncomeTaxRule(0, 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => rule.GetTax(salary));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void GetTax_invalid_percent_return_0(decimal percent, decimal expected)
        {
            var rule = new IncomeTaxRule(percent, 0);

            var res = rule.GetTax(1);

            Assert.Equal(expected, res);
        }
    }
}
