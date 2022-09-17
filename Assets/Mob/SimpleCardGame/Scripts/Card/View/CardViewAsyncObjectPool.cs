using System;
using UniRx;
using UniRx.Toolkit;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Mob.SimpleCardGame.Scripts.Card.View
{
    /// <summary>
    ///     CardViewのAsyncObjectPool
    /// </summary>
    public sealed class CardViewAsyncObjectPool : AsyncObjectPool<CardView>
    {
        private readonly Transform _parent;

        public CardViewAsyncObjectPool(Transform parent)
        {
            _parent = parent;
        }

        protected override IObservable<CardView> CreateInstanceAsync()
        {
            var prefab = Resources.Load<CardView>("SimpleCardGame/Prefabs/Card");
            var go = Object.Instantiate(prefab, _parent);
            return Observable.Return(go);
        }

        protected override void OnBeforeRent(CardView instance)
        {
            instance.Initialize();
            base.OnBeforeRent(instance);
        }
    }
}
