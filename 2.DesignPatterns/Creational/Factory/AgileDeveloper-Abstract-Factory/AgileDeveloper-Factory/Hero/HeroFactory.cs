using AgileDeveloper_Abstract_Factory.Hero.Heros;
using AgileDeveloper_Factory.Hero.Heros;

namespace AgileDeveloper_Factory.Hero;
internal class HeroFactory
{
    public static IHero Create(string hero)
    {
        if (hero == "a")
        {
            return new Axe();
        }
        else if (hero == "r")
        {
            return new Razor();
        }
        else if (hero == "i")
        {
            return new IO();
        }
        else if (hero == "t")
        {
            return new TestHero();
        }
        else
        {
            throw new ArgumentException("the given hero name is not valid", hero);
        }
    }
}
