using System;
using System.Collections.Generic;
using UnityEngine;

namespace MOB.HoRogue.Services
{
    public static class ServiceManager
    {
        private static Dictionary<Type, IService> services = new Dictionary<Type, IService>();

        public static void AddService(IService service) => services.Add(service.GetType(), service);

        /// <summary>
        /// サービスを取得します
        /// </summary>
        /// <typeparam name="TService">サービスクラスの型</typeparam>
        public static TService GetService<TService>() where TService : IService, new()
        {
            if (!services.ContainsKey(typeof(TService)))
            {
                Debug.LogError($"登録されていないサービス : {nameof(TService)}");
                return default;
            }

            return (TService)services[typeof(TService)];
        }
    }
}
