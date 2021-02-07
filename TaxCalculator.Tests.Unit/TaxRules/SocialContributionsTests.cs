using System;
using TaxCalculator.BL.TaxRules;
using Xunit;

namespace TaxCalculator.Tests.Unit.TaxRules
{
    public class SocialContributionsTests
    {
        [Theory]
        [InlineData(0, 0, 50, 4000, 2000)]
        [InlineData(0, 3000, 20, 2500, 500)]
        [InlineData(2000, 3000, 10, 2500, 50)]
        [InlineData(2000, 3000, 25, 5000, 250)]
        [InlineData(1000, 3000, 15, 3400, 300)]
        [InlineData(1000, 3000, 10, 3400, 200)]
        [InlineData(3000, 1000, 10, 3400, 0)]
        public void GetTax_correct_values(decimal minApplyAmount, decimal maxApplyAmount, decimal percent, decimal salary, decimal expected)
        {
            var rule = new SocialContributionsRule(percent, minApplyAmount, maxApplyAmount);

            var res = rule.GetTax(salary);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetTax_invalid_percent_must_throw(decimal salary)
        {
            var rule = new SocialContributionsRule(0, 0, 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => rule.GetTax(salary));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void GetTax_invalid_percent_return_0(decimal percent, decimal expected)
        {
            var rule = new SocialContributionsRule(percent, 0, 0);

            var res = rule.GetTax(1);

            Assert.Equal(expected, res);
        }
    }
}
