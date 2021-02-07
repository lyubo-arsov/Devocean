namespace TaxCalculator.BL.TaxRules
{
    public class IncomeTaxRule : TaxRuleBase
    {
        public IncomeTaxRule(decimal percent, decimal minApplyAmount) : base(percent, minApplyAmount)
        {
        }

        protected override decimal GetAmountToTaxate(decimal salary)
        {
            return salary - MinApplyAmount;
        }
    }
}
