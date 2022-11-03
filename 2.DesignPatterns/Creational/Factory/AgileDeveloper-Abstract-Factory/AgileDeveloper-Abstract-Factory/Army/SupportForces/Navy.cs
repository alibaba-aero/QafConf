namespace AgileDeveloper_Abstract_Factory.Army.SupportForces;
internal class Navy : ISupportForce
{
    public string Name => "Navy";

    public void DestroyDefends()
    {
        Console.WriteLine($"Ships of the {Name} are attacking enemy artilleries");
    }
}
