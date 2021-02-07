namespace TaxCalculator.BL.Services
{
    public interface ICalculator
    {
        decimal ApplyTaxes(decimal salary);
    }
}