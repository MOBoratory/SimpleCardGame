namespace Mob.SimpleCardGame.Scripts.Card.Model
{
    /// <summary>
    /// CardModel
    /// </summary>
    public sealed class CardVO
    {
        public uint CardId { get;  }
        public string Name { get;  }
        
        public uint Power { get;  }
        public uint Defense { get; }

        public CardVO(uint cardId, string name, uint power, uint defense)
        {
            CardId = cardId;
            Name = name;

            Power = power;
            Defense = defense;
        }
    }
}
