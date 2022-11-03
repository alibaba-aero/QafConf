using AgileDeveloper_Abstract_Factory.Hero.Heros;
using AgileDeveloper_Factory.Hero;

while (true)
{
    Play();
}

static void Play()
{
    Console.WriteLine("Choose your hero : (A)xe, (R)azor,(I)O");
    var enteredHero = Console.ReadLine().ToLower();
    var hero = HeroFactory.Create(enteredHero);
    hero.Attack();
    Console.WriteLine("--------------------");
}