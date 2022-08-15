namespace Qaf.Solutions.DesignPattern.Imp;

public class VatCalculator : IFlatTaxCalculator
{
    private readonly int _income;
    private readonly decimal _ratio;

    public VatCalculator(int income, decimal ratio)
    {
        _income = income;
        _ratio = ratio;
    }

    public decimal Calculate()
    {
        return _income * _ratio;
    }
}