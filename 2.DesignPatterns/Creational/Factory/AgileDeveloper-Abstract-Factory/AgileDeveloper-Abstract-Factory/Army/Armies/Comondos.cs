namespace AgileDeveloper_Abstract_Factory.Army.Armies;
internal class Comondos : IArmy
{
    public string Name => "Comondos";

    public void Prepare()
    {
        Console.WriteLine($"{Name} are going to attack the target");
    }
}
