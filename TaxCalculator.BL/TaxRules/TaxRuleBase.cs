using System;

namespace TaxCalculator.BL.TaxRules
{
    public abstract class TaxRuleBase : ITaxRule
    {
        public TaxRuleBase(decimal percent, decimal minApplyAmount)
        {
            // This could throw an exception
            Percent = percent < 0 ? 0 : percent;
            MinApplyAmount = minApplyAmount < 0 ? 0 : minApplyAmount;
        }

        public decimal Percent { get; }
        protected decimal MinApplyAmount { get; }
        public virtual decimal GetTax(decimal salary)
        {
            ValidateSalary(salary);

            decimal ret = 0;
            var amountToTaxate = GetAmountToTaxate(salary);
            if (amountToTaxate > 0)
            {
                ret = (amountToTaxate / 100) * Percent;
            }

            return ret;
        }
        protected abstract decimal GetAmountToTaxate(decimal salary);
        protected virtual void ValidateSalary(decimal salary)
        {
            if (salary <= 0)
            {
                throw new ArgumentOutOfRangeException("Salary is less than 0.");
            }
        }

    }
}
