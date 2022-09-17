using System;
using System.Collections.Generic;
using Mob.SimpleCardGame.Scripts.Service;

namespace MOB.Services
{
    public class ServiceBundle
    {
        public static IEnumerable<Type> GetServiceTypes()
        {
            return new[]
            {
                typeof(SceneService),
                typeof(MasterService)
            };
        }
    }
}
