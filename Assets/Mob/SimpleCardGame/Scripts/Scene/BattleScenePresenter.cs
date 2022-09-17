using System.Linq;
using Cysharp.Threading.Tasks;
using ExtraLinq;
using MOB.Scenes.Presenter;
using MOB.Services;
using Mob.SimpleCardGame.Scripts.Card.Model;
using Mob.SimpleCardGame.Scripts.Card.View;
using Mob.SimpleCardGame.Scripts.Service;
using UniRx;
using UnityEngine;

namespace Mob.SimpleCardGame.Scripts.Scene
{
    /// <summary>
    ///     BattleScenePresenter
    /// </summary>
    public sealed class BattleScenePresenter : ScenePresenterBase
    {
        [SerializeField] private BattleSceneView _sceneView;
        private readonly CardViewAsyncObjectPool _cardViewAsyncObjectPool = new();

        private void OnDestroy()
        {
            _cardViewAsyncObjectPool?.Dispose();
        }

        public override async UniTask InitializeAsync()
        {
            _sceneView.Initialize();

            _sceneView.DrawCardButtonAsObservable.SelectMany(_ => _cardViewAsyncObjectPool.RentAsync())
                .Subscribe(x =>
                {
                    _sceneView.SetParentCardView(x);
                    x.Setup(CreateCardViewModel());
                    x.Show();
                })
                .AddTo(this);

            _sceneView.SetActiveDrawCardButton(true);
        }

        /// <summary>
        ///     CardViewModelを作成します
        /// </summary>
        /// <returns>新規Instance</returns>
        private CardViewModel CreateCardViewModel()
        {
            var masterService = ServiceManager.GetService<MasterService>();
            // NOTE: ランダムに取得
            var randomCardMaster = masterService.GetAll()
                .Shuffle()
                .First();
            var cardMaster = masterService.GetById(randomCardMaster.CardId);
            var cardVO = new CardVO(cardMaster);
            return new CardViewModel(cardVO);
        }
    }
}
