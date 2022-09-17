namespace Mob.SimpleCardGame.Scripts.Card.Model
{
    /// <summary>
    /// CardViewModel
    /// </summary>
    public sealed class CardViewModel
    {
        private CardVO CardVO { get; }

        public string CardName => CardVO.Name;
        
        public CardViewModel(CardVO cardVO)
        {
            CardVO = cardVO;
        }
    }
}