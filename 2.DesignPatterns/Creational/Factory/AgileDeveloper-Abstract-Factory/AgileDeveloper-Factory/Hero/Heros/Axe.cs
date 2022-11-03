using AgileDeveloper_Factory.Hero;

namespace AgileDeveloper_Abstract_Factory.Hero.Heros;
internal class Axe : IHero
{
    public void Attack()
    {
        Console.WriteLine("Axe attacks with power of 10");
    }
}
