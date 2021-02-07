namespace TaxCalculator.ConsoleApp.Settings
{
    public class AppSettings
    {
        public AppSettings(SocialContributionsSettings socialContributionsSettings, IncomeTaxSettings incomeTaxSettings)
        {
            SocialContributions = socialContributionsSettings;
            IncomeTax = incomeTaxSettings;
        }
        public SocialContributionsSettings SocialContributions { get; set; }
        public IncomeTaxSettings IncomeTax { get; set; }
    }
}
