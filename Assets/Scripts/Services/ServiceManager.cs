using System;
using System.Collections.Generic;
using UnityEngine;

namespace MOB.Services
{
    public static class ServiceManager
    {
        private static readonly Dictionary<Type, IService> services = new();

        public static void AddService(IService service)
        {
            services.Add(service.GetType(), service);
        }

        /// <summary>
        ///     サービスを取得します
        /// </summary>
        /// <typeparam name="TService">サービスクラスの型</typeparam>
        public static TService GetService<TService>() where TService : IService, new()
        {
            if (!services.ContainsKey(typeof(TService)))
            {
                Debug.LogError($"登録されていないサービス : {nameof(TService)}");
                return default;
            }

            return (TService) services[typeof(TService)];
        }
    }
}
