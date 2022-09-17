using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Card.View
{
    /// <summary>
    ///     CardViewをまとめるView
    /// </summary>
    public sealed class CardGroupView : MonoBehaviour
    {
        [SerializeField] private RectTransform _cardViewParent;

        public RectTransform CardViewParent => _cardViewParent;
    }
}
