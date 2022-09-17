using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Master
{
    [CreateAssetMenu(fileName = "CardMaster", menuName = "CreateCardMaster", order = 1)]
    public sealed class CardMaster : ScriptableObject
    {
        [SerializeField] private uint _cardId;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _cardSprite;

        [SerializeField] private uint _power;
        [SerializeField] private uint _defense;

        public uint CardId => _cardId;

        public string Name => _name;
        public Sprite CardSprite => _cardSprite;

        public uint Power => _power;
        public uint Defense => _defense;
    }
}
