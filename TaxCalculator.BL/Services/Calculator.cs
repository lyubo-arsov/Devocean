using System;
using System.Collections.Generic;
using TaxCalculator.BL.TaxRules;

namespace TaxCalculator.BL.Services
{
    public class Calculator : ICalculator
    {
        public Calculator(IEnumerable<ITaxRule> taxRules)
        {
            TaxRules = taxRules;
        }
        protected IEnumerable<ITaxRule> TaxRules { get; }

        protected bool ValidateSalary(decimal salary)
        {
            return salary > 0;
        }
        public decimal ApplyTaxes(decimal salary)
        {
            if (!ValidateSalary(salary))
            {
                Console.WriteLine("There was no instructions in the project requirements how to handle such situations.");
                Console.WriteLine($"Salary: {salary}");

                return 0;
            }

            var ret = salary;
            foreach (var rule in TaxRules)
            {
                ret -= rule.GetTax(salary);
            }
            // Handle the case when the total of taxes to be applied exceeds the salary.
            if (ret < 0)
            {
                ret = 0;
            }

            return Math.Round(ret, 2);
        }
    }
}
