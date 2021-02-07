using Moq;
using System.Collections.Generic;
using TaxCalculator.BL.Services;
using TaxCalculator.BL.TaxRules;
using Xunit;

namespace TaxCalculator.Tests.Unit.Services
{
    public class CalculatorTests
    {
        [Fact]
        public void Ensure_tax_rules_are_called_unce()
        {
            decimal minAmount = 0;
            decimal maxAmount = 0;
            decimal percent = 10;
            var rule1 = new Mock<IncomeTaxRule>(new object[] { percent, minAmount });
            var rule2 = new Mock<SocialContributionsRule>(new object[] { percent, minAmount, maxAmount });
            var calc = new Calculator(new List<ITaxRule> { rule1.Object, rule2.Object });
            decimal salary = 1000;

            var res = calc.ApplyTaxes(salary);

            rule1.Verify(m => m.GetTax(salary), Times.Once());
            rule2.Verify(m => m.GetTax(salary), Times.Once());
        }

    }
}
