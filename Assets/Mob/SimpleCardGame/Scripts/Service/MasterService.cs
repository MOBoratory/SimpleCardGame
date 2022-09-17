using System.Collections.Generic;
using System.Linq;
using MOB.Services;
using Mob.SimpleCardGame.Scripts.Master;

namespace Mob.SimpleCardGame.Scripts.Service
{
    /// <summary>
    ///     MasterService
    /// </summary>
    public sealed class MasterService : IService
    {
        private readonly CardMasterRepository _cardMasterRepository;

        public MasterService()
        {
            _cardMasterRepository = new CardMasterRepository();
            _cardMasterRepository.CreateCaches();
        }

        /// <summary>
        ///     全てのマスターを取得します
        /// </summary>
        public IEnumerable<CardMaster> GetAll()
        {
            return _cardMasterRepository.CardMasterCaches.Values.ToList();
        }

        /// <summary>
        ///     CardMasterを取得します
        /// </summary>
        public CardMaster GetById(uint cardId)
        {
            return _cardMasterRepository.CardMasterCaches[cardId];
        }

        /// <summary>
        ///     CardMaster取得を試します
        /// </summary>
        public bool TryGetById(uint cardId, out CardMaster cardMaster)
        {
            return _cardMasterRepository.CardMasterCaches.TryGetValue(cardId, out cardMaster);
        }
    }
}
