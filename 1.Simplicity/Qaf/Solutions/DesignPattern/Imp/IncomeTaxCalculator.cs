namespace Qaf.Solutions.DesignPattern.Imp;

public class IncomeTaxCalculator : IRelativeTaxCalculator
{
    private readonly int _income;
    private readonly decimal _ratio;

    public IncomeTaxCalculator(int income, decimal ratio)
    {
        _income = income;
        _ratio = ratio;
    }

    public decimal Calculate(decimal currentTax)
    {
        return (_income - currentTax) * _ratio;
    }
}