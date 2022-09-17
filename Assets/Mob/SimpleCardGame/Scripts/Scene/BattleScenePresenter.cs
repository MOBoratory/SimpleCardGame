using System.Linq;
using Cysharp.Threading.Tasks;
using ExtraLinq;
using MOB.HoRogue.Scenes;
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
    [RequireComponent(typeof(BattleSceneView))]
    public sealed class BattleScenePresenter : ScenePresenterBase, IScene
    {
        [SerializeField] private BattleSceneView _sceneView;

        private CardViewAsyncObjectPool _cardViewAsyncObjectPool;

        private void OnDestroy()
        {
            _cardViewAsyncObjectPool?.Dispose();
        }

        public override async UniTask InitializeAsync()
        {
            // CardViewPoolを初期化
            var cardViewPoolParent = new GameObject($"{nameof(CardView)}Pool");
            cardViewPoolParent.transform.SetParent(transform, false);
            _cardViewAsyncObjectPool = new CardViewAsyncObjectPool(cardViewPoolParent.transform);
            _cardViewAsyncObjectPool.PreloadAsync(5, 1)
                .Subscribe()
                .AddTo(this);

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
