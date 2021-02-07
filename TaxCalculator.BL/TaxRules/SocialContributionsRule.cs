namespace TaxCalculator.BL.TaxRules
{
    public class SocialContributionsRule : TaxRuleBase
    {
        // If maxAplyAmount is 0 it will be ignored
        public SocialContributionsRule(decimal percent, decimal minApplyAmount, decimal maxApplyAmount) : base(percent, minApplyAmount)
        {
            MaxApplyAmount = maxApplyAmount;
        }

        public decimal MaxApplyAmount { get; }

        protected override decimal GetAmountToTaxate(decimal salary)
        {
            decimal ret = salary - MinApplyAmount;
            if (salary > MaxApplyAmount && MaxApplyAmount > 0)
            {
                ret = MaxApplyAmount - MinApplyAmount;
            }

            return ret;
        }
    }
}
