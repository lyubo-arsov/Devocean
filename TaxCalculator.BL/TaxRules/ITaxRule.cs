namespace TaxCalculator.BL.TaxRules
{
    public interface ITaxRule
    {
        decimal GetTax(decimal salary);
        decimal Percent { get; }
    }
}
