namespace Qaf.Solutions.DesignPattern.Imp;

public class TaxCalculator : ITaxCalculator
{
    private readonly IFlatTaxCalculator _vatCalculator;
    private readonly IRelativeTaxCalculator _corporateCalculator;
    private readonly IRelativeTaxCalculator _incomeCalculator;
    public TaxCalculator(int income, decimal vatRatio, decimal corporateRatio, decimal itRatio)
    {
        _vatCalculator = new VatCalculator(income, vatRatio);
        _corporateCalculator = new CorporateIncomeCalculator(income, corporateRatio);
        _incomeCalculator = new IncomeTaxCalculator(income, itRatio);
    }

    public decimal Calculate()
    {
        var vatTax = _vatCalculator.Calculate();
        var ctrTax = _corporateCalculator.Calculate(vatTax);
        var itTax = _incomeCalculator.Calculate(ctrTax);

        var total = vatTax + ctrTax + itTax;

        return total;
    }
}