using System;
using Mob.SimpleCardGame.Scripts.Card.View;
using Mob.UI;
using UniRx;
using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Scene
{
    /// <summary>
    ///     BattleSceneView
    /// </summary>
    public sealed class BattleSceneView : MonoBehaviour
    {
        [SerializeField] private CardGroupView _cardGroupView;
        [SerializeField] private MobButton _drawCardButton;

        public IObservable<Unit> DrawCardButtonAsObservable => _drawCardButton.OnClickThrottleFirstAsObservable;

        public void Initialize()
        {
            SetActiveDrawCardButton(false);
        }

        public void SetActiveDrawCardButton(bool active)
        {
            _drawCardButton.gameObject.SetActive(active);
        }

        /// <summary>
        ///     CardViewの親を設定します
        /// </summary>
        /// <param name="cardViewInstance">CardViewのInstance</param>
        public void SetParentCardView(CardView cardViewInstance)
        {
            cardViewInstance.transform.SetParent(_cardGroupView.CardViewParent, false);
        }
    }
}
