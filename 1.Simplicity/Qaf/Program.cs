// Problem :
// Ask user company name,income and the year of calculation.
// calculate the tax and balanace of the company.
// Assumptions :

// |   YEAR   |  Income(M$) |   VAT(%)    |  Corporate Tax Rate(%)  |    Income Tax(%)   |
// |----------|-------------|-------------|-------------------------|--------------------|
// |  <2021   |      <3     |  I * 0.00   |    (I - VAT) * 0.02     |  (I - CTR) * 0.00  |
// |  <2021   |   3>= & <5  |  I * 0.05   |    (I - VAT) * 0.05     |  (I - CTR) * 0.10  |
// |  <2021   |   5>= & <8  |  I * 0.05   |    (I - VAT) * 0.05     |  (I - CTR) * 0.20  |
// |  <2021   |     >=8     |  I * 0.05   |    (I - VAT) * 0.06     |  (I - CTR) * 0.25  |
// |   2021   |      <3     |  I * 0.08   |    (I - VAT) * 0.02     |  (I - CTR) * 0.01  |
// |   2021   |   3>= & <5  |  I * 0.08   |    (I - VAT) * 0.06     |  (I - CTR) * 0.15  |
// |   2021   |   5>= & <8  |  I * 0.08   |    (I - VAT) * 0.06     |  (I - CTR) * 0.22  |
// |   2021   |     >=8     |  I * 0.08   |    (I - VAT) * 0.08     |  (I - CTR) * 0.26  |
// |   2022   |      <3     |  I * 0.09   |    (I - VAT) * 0.02     |  (I - CTR) * 0.01  |
// |   2022   |   3>= & <5  |  I * 0.09   |    (I - VAT) * 0.07     |  (I - CTR) * 0.16  |
// |   2022   |   5>= & <8  |  I * 0.09   |    (I - VAT) * 0.06     |  (I - CTR) * 0.15  |
// |   2022   |     >=8     |  I * 0.09   |    (I - VAT) * 0.01     |  (I - CTR) * 0.27  |

// Solution One

using Qaf.Solutions.DesignPattern;

var justMakeItWorkSolution = new JustMakeItWorkSolution();
justMakeItWorkSolution.RunSample();

Console.ReadLine();

var cleanCodeSolution = new CleanCodeSolution();
cleanCodeSolution.RunSample();

Console.ReadLine();

var designPatternSolution = new DesignPatternSolution();
designPatternSolution.RunSample();

Console.ReadKey();