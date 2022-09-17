using System;
using Mob.SimpleCardGame.Scripts.Card.Model;
using Mob.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Mob.SimpleCardGame.Scripts.Card.View
{
    /// <summary>
    ///     CardView
    /// </summary>
    public sealed class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Image _cardImage;

        [SerializeField] private MobButton _selectButton;

        public IObservable<Unit> OnSelectButtonThrottleFirstAsObservable =>
            _selectButton.OnClickThrottleFirstAsObservable;

        public void Initialize()
        {
            _selectButton.SetInteractable(false);
        }

        /// <summary>
        ///     CardViewを設定します
        /// </summary>
        /// <param name="cardViewModel">ViewModel</param>
        public void Setup(CardViewModel cardViewModel)
        {
            _nameText.text = cardViewModel.CardName;
            _cardImage.sprite = cardViewModel.CardSprite;

            _selectButton.SetInteractable(true);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
