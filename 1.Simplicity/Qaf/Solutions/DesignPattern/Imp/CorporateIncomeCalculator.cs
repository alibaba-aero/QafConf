namespace Qaf.Solutions.DesignPattern.Imp;

public class CorporateIncomeCalculator : IRelativeTaxCalculator
{
    private readonly int _income;
    private readonly decimal _ratio;

    public CorporateIncomeCalculator(int income, decimal ratio)
    {
        _income = income;
        _ratio = ratio;
    }

    public decimal Calculate(decimal currentTax)
    {
        return (_income - currentTax) * _ratio;
    }
}