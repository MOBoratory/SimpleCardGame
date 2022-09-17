using Mob.SimpleCardGame.Scripts.Master;
using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Card.Model
{
    /// <summary>
    ///     CardModel
    /// </summary>
    public struct CardVO
    {
        public CardVO(CardMaster cardMaster) :
            this(
                cardMaster.CardId,
                cardMaster.Name,
                cardMaster.Power,
                cardMaster.Defense,
                cardMaster.CardSprite
            )
        {
        }

        public CardVO(uint cardId, string cardName, uint power, uint defense, Sprite cardSprite)
        {
            CardId = cardId;
            CardName = cardName;

            Power = power;
            Defense = defense;

            CardSprite = cardSprite;
        }

        public uint CardId { get; }
        public string CardName { get; }

        public uint Power { get; }
        public uint Defense { get; }

        public Sprite CardSprite { get; }
    }
}
