namespace Qaf;
internal class CleanCodeSolution
{
    public void RunSample()
    {
        var companyName = GetCompanyName();
        var year = GetCalculationYear(companyName);
        var companyIncome = GetCompanyIncome(year);

        var tax = 0m;
        if (year <= 2020)
        {
            tax = CalculateUnder2020(companyIncome, tax);
        }
        else if (year == 2021)
        {
            tax = Calculate2021(companyIncome, tax);
        }
        else if (year == 2022)
        {
            tax = Calculate2022(companyIncome, tax);
        }
        var balance = CalculateCompanyBalance(companyIncome, tax);
        WriteTaxAndBalanceResult(companyName, year, tax, balance);
    }

    private static string GetCompanyName()
    {
        Console.WriteLine("Please enter the company name : ");
        var companyName = Console.ReadLine();
        return companyName;
    }
    private static int GetCalculationYear(string companyName)
    {
        Console.WriteLine("Please enter the year of calculation for " + companyName + " :");
        var _year = Console.ReadLine();
        var year = _year.ToCharArray().All(c => Char.IsDigit(c)) ? int.Parse(_year) : 0;
        return year;
    }
    private static int GetCompanyIncome(int year)
    {
        Console.WriteLine("Please enter the company income for the " + year + " year in Million: ");
        var _companyIncome = Console.ReadLine();
        var companyIncome = _companyIncome.ToCharArray().All(c => Char.IsDigit(c)) ? int.Parse(_companyIncome) : 0;
        return companyIncome;
    }
    private static decimal CalculateUnder2020(int companyIncome, decimal tax)
    {
        if (companyIncome < 3)
        {
            var vat = (companyIncome * 0.00m);
            var corprateTaxRate = ((companyIncome - vat) * 0.02m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0m;
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome >= 3 && companyIncome < 5)
        {
            var vat = (companyIncome * 0.05m);
            var corprateTaxRate = ((companyIncome - vat) * 0.05m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.1m;
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome >= 5 && companyIncome < 8)
        {
            var vat = (companyIncome * 0.05m);
            var corprateTaxRate = ((companyIncome - vat) * 0.05m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.02m;
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome > 8)
        {
            var vat = (companyIncome * 0.05m);
            var corprateTaxRate = ((companyIncome - vat) * 0.06m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.25m;
            tax = vat + corprateTaxRate + incomeTax;
        }

        return tax;
    }
    private static decimal Calculate2021(int companyIncome, decimal tax)
    {
        if (companyIncome < 3)
        {
            var vat = (companyIncome * 0.08m);
            var corprateTaxRate = ((companyIncome - vat) * 0.02m);
            var incomeTax = (companyIncome - corprateTaxRate * 0.01m);
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome >= 3 && companyIncome < 5)
        {
            var vat = (companyIncome * 0.08m);
            var corprateTaxRate = ((companyIncome - vat) * 0.06m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.15m;
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome >= 5 && companyIncome < 8)
        {
            var vat = (companyIncome * 0.08m);
            var corprateTaxRate = ((companyIncome - vat) * 0.06m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.22m;
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome > 8)
        {
            var vat = (companyIncome * 0.08m);
            var corprateTaxRate = ((companyIncome - vat) * 0.08m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.26m;
            tax = vat + corprateTaxRate + incomeTax;
        }

        return tax;
    }
    private static decimal Calculate2022(int companyIncome, decimal tax)
    {
        if (companyIncome < 3)
        {
            var vat = (companyIncome * 0.09m);
            var corprateTaxRate = ((companyIncome - vat) * 0.02m);
            var incomeTax = (companyIncome - corprateTaxRate * 0.01m);
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome >= 3 && companyIncome < 5)
        {
            var vat = (companyIncome * 0.09m);
            var corprateTaxRate = ((companyIncome - vat) * 0.07m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.16m;
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome >= 5 && companyIncome < 8)
        {
            var vat = (companyIncome * 0.09m);
            var corprateTaxRate = ((companyIncome - vat) * 0.06m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.15m;
            tax = vat + corprateTaxRate + incomeTax;
        }
        else if (companyIncome > 8)
        {
            var vat = (companyIncome * 0.09m);
            var corprateTaxRate = ((companyIncome - vat) * 0.01m);
            var incomeTax = (companyIncome - corprateTaxRate) * 0.27m;
            tax = vat + corprateTaxRate + incomeTax;
        }

        return tax;
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
