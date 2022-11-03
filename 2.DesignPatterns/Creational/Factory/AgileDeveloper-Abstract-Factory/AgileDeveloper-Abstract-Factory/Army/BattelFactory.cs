namespace AgileDeveloper_Abstract_Factory.Army;
internal class BattelFactory
{
    internal static IBattelFactory BuildBattel(string type)
    {
        if (type == "m")
        {
            return new MointainsBattel();
        }
        else if (type == "p")
        {
            return new PortBattel();
        }

        throw new ArgumentException("I don't know anything about this battel type.");
    }
}

