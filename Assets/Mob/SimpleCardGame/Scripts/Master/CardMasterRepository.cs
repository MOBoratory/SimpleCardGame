using System.Collections.Generic;
using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Master
{
    public sealed class CardMasterRepository
    {
        private const string MasterResourcesDirectoryPath = "Master/CardMaster";

        private readonly Dictionary<uint, CardMaster> _cardMasterCaches = new();

        public IReadOnlyDictionary<uint, CardMaster> CardMasterCaches => _cardMasterCaches;

        public void CreateCaches()
        {
            _cardMasterCaches.Clear();
            var cardMasters = Resources.LoadAll<CardMaster>(MasterResourcesDirectoryPath);
            foreach (var cardMaster in cardMasters) _cardMasterCaches.TryAdd(cardMaster.CardId, cardMaster);
        }
    }
}
