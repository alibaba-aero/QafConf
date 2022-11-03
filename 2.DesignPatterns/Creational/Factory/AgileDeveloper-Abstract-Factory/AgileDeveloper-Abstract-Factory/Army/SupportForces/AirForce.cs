namespace AgileDeveloper_Abstract_Factory.Army.SupportForces;
internal class AirForce : ISupportForce
{
    public string Name => "Air Force";

    public void DestroyDefends()
    {
        Console.WriteLine($"Aircrafts of the {Name}, destroyed enemy defends...");
    }
}
