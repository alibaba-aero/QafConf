using AgileDeveloper_Abstract_Factory.Army;
while (true)
{
    Play();
}

static void Play()
{
    Console.WriteLine("Choose your Battel type : (M)ountain , (P)ort");
    var battelType = Console.ReadLine().ToLower();
    var battel = BattelFactory.BuildBattel(battelType);
    
    var support =  battel.CreateSupport();
    var armies = battel.CreateArmy();

    support.DestroyDefends();
    armies.Prepare();

    Console.WriteLine("--------------------");
}