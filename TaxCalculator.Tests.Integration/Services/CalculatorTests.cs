using System.Collections.Generic;
using TaxCalculator.BL.Services;
using TaxCalculator.BL.TaxRules;
using Xunit;

namespace TaxCalculator.Tests.Integration.Services
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(100, 30, 300, 240)]
        [InlineData(0, 15, 100, 85)]
        [InlineData(100, 10, 100, 100)]
        public void CalculateTaxes_income_tax_correct_values(decimal minApplyAmount, decimal percent, decimal salary, decimal expected)
        {
            var rule = new IncomeTaxRule(percent, minApplyAmount);
            var calc = new Calculator(new List<ITaxRule> { rule });

            var res = calc.ApplyTaxes(salary);

            Assert.Equal(res, expected);
        }

        [Theory]
        [InlineData(0, 0, 50, 4000, 2000)]
        [InlineData(0, 3000, 20, 2500, 2000)]
        [InlineData(2000, 3000, 10, 2500, 2450)]
        [InlineData(2000, 3000, 25, 5000, 4750)]
        [InlineData(2000, 3000, 15, 3400, 3250)]
        [InlineData(2000, 3000, -15, 3400, 3400)]
        [InlineData(1000, 3000, 10, 3400, 3200)]
        public void CalculateTaxes_social_contribution_correct_values(decimal minApplyAmount, decimal maxApplyAmount, decimal percent, decimal salary, decimal expected)
        {
            var rule = new SocialContributionsRule(percent, minApplyAmount, maxApplyAmount);
            var calc = new Calculator(new List<ITaxRule> { rule });

            var res = calc.ApplyTaxes(salary);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(1000, 3000, 10, 15, 2500, 2125)]
        [InlineData(1000, 3000, 10, 15, 3400, 2860)]
        [InlineData(3000, 1000, 10, 15, 3400, 3360)]
        [InlineData(3000, 1000, -10, 15, 3400, 3400)]
        [InlineData(1000, 3000, 10, 15, 980, 980)]
        [InlineData(1000, 3000, 10, -15, 980, 980)]
        public void CalculateTaxes_all_rules_correct_values(decimal minApplyAmount, decimal maxApplyAmount, decimal percent1, decimal percent2, decimal salary, decimal expected)
        {
            var rule1 = new IncomeTaxRule(percent1, minApplyAmount);
            var rule2 = new SocialContributionsRule(percent2, minApplyAmount, maxApplyAmount);
            var calc = new Calculator(new List<ITaxRule> { rule1, rule2 });

            var res = calc.ApplyTaxes(salary);

            Assert.Equal(expected, res);
        }

        [Fact]
        public void CalculateTaxes_invalid_salary_must_return_0()
        {
            var rule1 = new IncomeTaxRule(10, 0);
            var rule2 = new SocialContributionsRule(15, 0, 0);
            var calc = new Calculator(new List<ITaxRule> { rule1, rule2 });

            var res = calc.ApplyTaxes(0);

            Assert.Equal(0, res);
        }

    }
}
