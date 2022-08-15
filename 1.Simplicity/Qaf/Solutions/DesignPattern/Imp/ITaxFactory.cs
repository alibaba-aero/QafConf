namespace Qaf.Solutions.DesignPattern.Imp;

public interface ITaxFactory
{
    ITaxCalculator GetUnder3MillionIncomeTaxCalculator();
    ITaxCalculator GetBetween3And5MillionIncomeTaxCalculator();
    ITaxCalculator GetBetween5AndUnder8MillionIncomeTaxCalculator();
    ITaxCalculator Above8MillionIncomeTaxCalculator();
    decimal Calculate(int income);
}