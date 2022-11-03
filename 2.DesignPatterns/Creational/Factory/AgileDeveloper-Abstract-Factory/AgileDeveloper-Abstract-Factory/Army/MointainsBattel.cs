﻿using AgileDeveloper_Abstract_Factory.Army.Armies;
using AgileDeveloper_Abstract_Factory.Army.SupportForces;

namespace AgileDeveloper_Abstract_Factory.Army;
internal class MointainsBattel : IBattelFactory
{
    public IArmy CreateArmy()
    {
        return new Comondos();
    }

    public ISupportForce CreateSupport()
    {
        return new AirForce();
    }
}
