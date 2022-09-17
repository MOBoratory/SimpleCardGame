using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UniRx.Toolkit;
using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Card.View
{
    /// <summary>
    /// CardViewのAsyncObjectPool
    /// </summary>
    public sealed class CardViewAsyncObjectPool : AsyncObjectPool<CardView>
    {
        protected override IObservable<CardView> CreateInstanceAsync()
        {
            return Resources.LoadAsync("SimpleCardGame/Card")
                .ToUniTask()
                .ToObservable()
                .Select(x => x as CardView);
        }

        protected override void OnBeforeRent(CardView instance)
        {
            instance.Initialize();
            base.OnBeforeRent(instance);
        }
    }
}