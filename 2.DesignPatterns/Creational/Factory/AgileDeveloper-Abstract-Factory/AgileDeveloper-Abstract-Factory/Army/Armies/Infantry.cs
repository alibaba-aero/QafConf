namespace AgileDeveloper_Abstract_Factory.Army.Armies;
internal class Infantry : IArmy
{
    public string Name => "Infantry";

    public void Prepare()
    {
        Console.WriteLine($"{Name} are in front line");
    }
}
