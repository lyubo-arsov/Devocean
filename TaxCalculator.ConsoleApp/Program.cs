using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TaxCalculator.BL.Services;
using TaxCalculator.BL.TaxRules;
using TaxCalculator.ConsoleApp.Settings;

namespace TaxCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = GetSettings();
            Calculator calculator = GetCalculator(settings);

            decimal salary = GetUserInput(args);

            var salaryAfterTaxes = calculator.ApplyTaxes(salary);

            Console.WriteLine($"Salary after taxes is {salaryAfterTaxes} IDR");

            Console.ReadKey();
        }

        private static decimal GetUserInput(string[] args)
        {
            decimal ret = 0;
            if (args.Length > 0)
            {
                decimal.TryParse(args[0], out ret);
            }
            while (ret <= 0)
            {
                Console.WriteLine("Enter salary in IDR (must be a positive number)");
                decimal.TryParse(Console.ReadLine(), out ret);
            }

            return ret;
        }

        private static Calculator GetCalculator(AppSettings settings)
        {
            var incomeTax = new IncomeTaxRule(
                            settings.IncomeTax.Percent,
                            settings.IncomeTax.MinApplyAmount
                            );
            var socialContributions = new SocialContributionsRule(
                settings.SocialContributions.Percent,
                settings.SocialContributions.MinApplyAmount,
                settings.SocialContributions.MaxApplyAmount
                );

            return new Calculator(new List<ITaxRule> { incomeTax, socialContributions });
        }

        private static AppSettings GetSettings(string file = "settings.json")
        {
            var conf = new ConfigurationBuilder()
                .AddJsonFile(file)
                .Build();

            // TODO fix the binding 
            var incomeTax = conf.GetSection("AppSettings:IncomeTax").Get<IncomeTaxSettings>();
            var socialContrib = conf.GetSection("AppSettings:SocialContributions").Get<SocialContributionsSettings>();

            return new AppSettings(socialContrib, incomeTax);
        }
    }
}
