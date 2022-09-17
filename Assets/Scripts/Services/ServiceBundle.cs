using System;
using System.Collections.Generic;

namespace MOB.HoRogue.Services
{
    public class ServiceBundle
    {
        public static IEnumerable<Type> GetServiceTypes()
        {
            return new[]
            {
                typeof(SceneService),
            };
        }
    }
}
