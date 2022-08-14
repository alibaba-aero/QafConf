namespace Qaf;
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
        Console.WriteLine("Tax for company [" + companyName + "] for year [" + year + "] is: [" + tax + "]. Company balance after tax should be : [" + balance + "]");
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
public class Year2021TaxFactory : ITaxFactory
{
    private readonly int _income;

    public Year2021TaxFactory(int income)
    {
        _income = income;
    }

    public ITaxCalculator GetUnder3MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.08m;
        var ctrRatio = 0.02m;
        var itRatio = 0.01m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator GetBetween3And5MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.8m;
        var ctrRatio = 0.06m;
        var itRatio = 0.15m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator GetBetween5AndUnder8MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.08m;
        var ctrRatio = 0.06m;
        var itRatio = 0.22m;
        return new TaxCalculator(_income, vatRatio, ctrRatio, itRatio);
    }

    public ITaxCalculator Above8MillionIncomeTaxCalculator()
    {
        var vatRatio = 0.08m;
        var ctrRatio = 0.08m;
        var itRatio = 0.26m;
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

public interface ITaxFactory
{
    ITaxCalculator GetUnder3MillionIncomeTaxCalculator();
    ITaxCalculator GetBetween3And5MillionIncomeTaxCalculator();
    ITaxCalculator GetBetween5AndUnder8MillionIncomeTaxCalculator();
    ITaxCalculator Above8MillionIncomeTaxCalculator();
    decimal Calculate(int income);
}
public interface ITaxCalculator
{
    decimal Calculate();
}
public class TaxCalculator : ITaxCalculator
{
    private readonly IFlatTaxCalculator _vatCalculator;
    private readonly IRelativeTaxCalculator _corporateCalculator;
    private readonly IRelativeTaxCalculator _incomeCalculator;
    public TaxCalculator(int income, decimal vatRatio, decimal corporateRatio, decimal itRatio)
    {
        _vatCalculator = new VATCalculator(income, vatRatio);
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
public interface IFlatTaxCalculator
{
    decimal Calculate();
}
public class VATCalculator : IFlatTaxCalculator
{
    private readonly int _income;
    private readonly decimal _ratio;

    public VATCalculator(int income, decimal ratio)
    {
        _income = income;
        _ratio = ratio;
    }

    public decimal Calculate()
    {
        return _income * _ratio;
    }
}
public interface IRelativeTaxCalculator
{
    decimal Calculate(decimal currentTax);
}
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