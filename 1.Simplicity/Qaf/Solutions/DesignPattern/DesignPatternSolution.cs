using Qaf.Solutions.DesignPattern.Imp;

namespace Qaf.Solutions.DesignPattern;

internal class DesignPatternSolution
{
    public void RunSample()
    {
        var companyName = GetCompanyName();
        var year = GetCalculationYear(companyName);
        var companyIncome = GetCompanyIncome(year);

        ITaxFactory taxFactory = GetTaxFactory(year, companyIncome);
        var tax = taxFactory.Calculate(companyIncome);
        var balance = CalculateCompanyBalance(companyIncome, tax);
        WriteTaxAndBalanceResult(companyName, year, tax, balance);
    }

    private ITaxFactory GetTaxFactory(int year, int income)
    {
        if (year < 2021)
            return new YearUnder2021TaxFactory(income);
        else if (year == 2021)
            return new Year2021TaxFactory(income);
        else if (year == 2022)
            return new Year2022TaxFactory(income);
        throw new Exception($"Year [{year}] is not supported");
    }

    private static int GetCompanyIncome(int year)
    {
        Console.WriteLine("Please enter the company income for the " + year + " year in Million: ");
        var _companyIncome = Console.ReadLine();
        var companyIncome = _companyIncome.ToCharArray().All(c => Char.IsDigit(c)) ? int.Parse(_companyIncome) : 0;
        return companyIncome;
    }

    private static int GetCalculationYear(string companyName)
    {
        Console.WriteLine("Please enter the year of calculation for " + companyName + " :");
        var _year = Console.ReadLine();
        var year = _year.ToCharArray().All(c => Char.IsDigit(c)) ? int.Parse(_year) : 0;
        return year;
    }

    private static string GetCompanyName()
    {
        Console.WriteLine("Please enter the company name : ");
        var companyName = Console.ReadLine();
        return companyName;
    }

    private static decimal CalculateCompanyBalance(int companyIncome, decimal tax)
    {
        return companyIncome - tax;
    }

    private static void WriteTaxAndBalanceResult(string companyName, int year, decimal tax, decimal balance)
    {
        Console.WriteLine("Tax for company [" + companyName + "] for year [" + year + "] is: [" + tax +
                          "]. Company balance after tax should be : [" + balance + "]");
    }
}

public class YearUnder2021TaxFactory : ITaxFactory
{
    private readonly int _income;

    public YearUnder2021TaxFactory(int income)
    {
        _income = income;
    }

    public ITaxCalculator GetUnder3MillionIncomeTaxCalculator()
    {
        var vatRatio = 0m;
        var ctrRatio = 0.02m;
        var itRatio = 0m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator GetBetween3And5MillionIncomeTaxCalculator()
    {
        var vatRatio = 00.5m;
        var ctrRatio = 0.05m;
        var itRatio = 0.1m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator GetBetween5AndUnder8MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.05m;
        var ctrRatio = 0.05m;
        var itRatio = 0.20m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator Above8MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.05m;
        var ctrRatio = 0.06m;
        var itRatio = 0.25m;
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