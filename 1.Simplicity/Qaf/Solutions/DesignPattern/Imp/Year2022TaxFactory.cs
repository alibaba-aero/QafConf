namespace Qaf.Solutions.DesignPattern.Imp;

public class Year2022TaxFactory : ITaxFactory
{
    private readonly int _income;

    public Year2022TaxFactory(int income)
    {
        _income = income;
    }

    public ITaxCalculator GetUnder3MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.09m;
        var ctrRatio = 0.02m;
        var itRatio = 0.01m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator GetBetween3And5MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.09m;
        var ctrRatio = 0.07m;
        var itRatio = 0.16m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator GetBetween5AndUnder8MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.09m;
        var ctrRatio = 0.06m;
        var itRatio = 0.15m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator Above8MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.09m;
        var ctrRatio = 0.01m;
        var itRatio = 0.27m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }
    public decimal Calculate(int income)
    {
        if (income < 3) return GetUnder3MillionIncomeTaxCalculator().Calculate();
        if (income >= 3 && income < 5) return GetBetween3And5MillionIncomeTaxCalculator().Calculate();
        if (income >= 5 && income < 8) return GetBetween5AndUnder8MillionIncomeTaxCalculator().Calculate();
        if (income > 8) return Above8MillionIncomeTaxCalculator().Calculate();
        return 0;
    }
}