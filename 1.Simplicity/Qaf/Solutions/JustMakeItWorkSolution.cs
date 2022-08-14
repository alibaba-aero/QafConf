namespace Qaf;
internal class JustMakeItWorkSolution
{
    public void RunSample()
    {
        Console.WriteLine("Please enter the company name : ");
        string cname = "";
        char k;
        do
        {
            int chCode = Console.Read();
            k = (char)chCode;
            cname = cname + k;
        } while (k != '\n' && k != '\r');

        cname = cname.TrimEnd('\r');
        cname = cname.TrimEnd('\n');
        cname = cname.TrimEnd('\r');

        Console.WriteLine("Please enter the year of calculation for " + cname + " :");

        int y = 0;
        string _y = "";
        Console.Read();
        k = default;
        do
        {
            int chCode = Console.Read();
            k = (char)chCode;
            if (char.IsDigit(k))
                _y = _y + k;
        } while (k != '\n' && k != '\r');
        y = int.Parse(_y);

        Console.WriteLine("Please enter the company income for the " + y + " year in Million: ");

        int ci = 0;
        string _ci = "";
        Console.Read();
        k = default;
        do
        {
            int chCode = Console.Read();
            k = (char)chCode;
            if (char.IsDigit(k))
                _ci = _ci + k;
        } while (k != '\n' && k != '\r');
        ci = int.Parse(_ci);

        if (y <= 2020)
        {
            decimal t = 0m;
            if (ci < 3)
            {
                t = (ci * 0.00m) + ((ci - (ci * 0.0m)) * 0.02m) + ((ci - ((ci - (ci * 0.0m)) * 0.02m)) * 0m);
            }
            else if (ci >= 3 && ci < 5)
            {
                t = (ci * 0.05m) + ((ci - (ci * 0.05m)) * 0.05m) + ((ci - ((ci - (ci * 0.05m)) * 0.05m)) * 0.1m);
            }
            else if (ci >= 5 && ci < 8)
            {
                t = (ci * 0.05m) + ((ci - (ci * 0.05m)) * 0.05m) + ((ci - ((ci - (ci * 0.05m)) * 0.05m)) * 0.2m);
            }
            else if (ci > 8)
            {
                t = (ci * 0.05m) + ((ci - (ci * 0.05m)) * 0.06m) + ((ci - ((ci - (ci * 0.05m)) * 0.05m)) * 0.25m);
            }
            decimal n = ci - t;
            Console.WriteLine("Tax for company [" + cname + "] for year [" + _y + "] is: [" + t + "]. Company balance after tax should be : [" + n + "]");
        }
        else if (y == 2021)
        {
            decimal t = 0m;
            if (ci < 3)
            {
                t = (ci * 0.08m) + ((ci - (ci * 0.8m)) * 0.02m) + ((ci - ((ci - (ci * 0.8m)) * 0.02m)) * 0.01m);
            }
            else if (ci >= 3 && ci < 5)
            {
                t = (ci * 0.08m) + ((ci - (ci * 0.08m)) * 0.06m) + ((ci - ((ci - (ci * 0.08m)) * 0.056m)) * 0.15m);
            }
            else if (ci >= 5 && ci < 8)
            {
                t = (ci * 0.08m) + ((ci - (ci * 0.08m)) * 0.06m) + ((ci - ((ci - (ci * 0.08m)) * 0.06m)) * 0.22m);
            }
            else if (ci > 8)
            {
                t = (ci * 0.08m) + ((ci - (ci * 0.08m)) * 0.08m) + ((ci - ((ci - (ci * 0.08m)) * 0.08m)) * 0.26m);
            }
            decimal n = ci - t;
            Console.WriteLine("Tax for company [" + cname + "] for year [" + _y + "] is: [" + t + "]. Company balance after tax should be : [" + n + "]");
        }
        else if (y == 2022)
        {
            decimal t = 0m;
            if (ci < 3)
            {
                t = (ci * 0.09m) + ((ci - (ci * 0.09m)) * 0.02m) + ((ci - ((ci - (ci * 0.09m)) * 0.02m)) * 0.01m);
            }
            else if (ci >= 3 && ci < 5)
            {
                t = (ci * 0.09m) + ((ci - (ci * 0.09m)) * 0.07m) + ((ci - ((ci - (ci * 0.09m)) * 0.07m)) * 0.16m);
            }
            else if (ci >= 5 && ci < 8)
            {
                t = (ci * 0.09m) + ((ci - (ci * 0.09m)) * 0.06m) + ((ci - ((ci - (ci * 0.09m)) * 0.06m)) * 0.15m);
            }
            else if (ci > 8)
            {
                t = (ci * 0.09m) + ((ci - (ci * 0.09m)) * 0.01m) + ((ci - ((ci - (ci * 0.09m)) * 0.01m)) * 0.27m);
            }
            decimal n = ci - t;
            Console.WriteLine("Tax for company [" + cname + "] for year [" + _y + "] is: [" + t + "]. Company balance after tax should be : [" + n + "]");
        }
    }
}
