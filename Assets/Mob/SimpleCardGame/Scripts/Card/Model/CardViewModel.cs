using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Card.Model
{
    /// <summary>
    ///     CardViewModel
    /// </summary>
    public sealed class CardViewModel
    {
        public CardViewModel(CardVO cardVO)
        {
            CardVO = cardVO;
        }

        private CardVO CardVO { get; }

        public string CardName => CardVO.CardName;
        public Sprite CardSprite => CardVO.CardSprite;
    }
}
