using Mob.SimpleCardGame.Scripts.Master;

namespace Mob.SimpleCardGame.Scripts.Card.Model
{
    /// <summary>
    ///     CardModel
    /// </summary>
    public sealed class CardVO
    {
        public CardVO(CardMaster cardMaster) :
            this(
                cardMaster.CardId,
                cardMaster.Name,
                cardMaster.Power,
                cardMaster.Defense
            )
        {
        }

        public CardVO(uint cardId, string name, uint power, uint defense)
        {
            CardId = cardId;
            Name = name;

            Power = power;
            Defense = defense;
        }

        public uint CardId { get; }
        public string Name { get; }

        public uint Power { get; }
        public uint Defense { get; }
    }
}
