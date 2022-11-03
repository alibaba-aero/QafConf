namespace AgileDeveloper_Abstract_Factory.Army;
internal interface IBattelFactory
{
    IArmy CreateArmy();
    ISupportForce CreateSupport();
}
