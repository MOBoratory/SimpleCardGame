using Cysharp.Threading.Tasks;
using MOB.Scenes.Presenter;
using Mob.SimpleCardGame.Scripts.Scene;
using Mob.UI;
using UniRx;
using UnityEngine;

namespace Mob.Scenes.Title
{
    public sealed class TitleScenePresenter : ScenePresenterBase
    {
        [SerializeField] private MobButton _startButton;

        public override async UniTask InitializeAsync()
        {
            _startButton.OnClickThrottleFirstAsObservable
                .FirstOrDefault()
                .Subscribe(_ => { sceneService.Value.LoadSceneAsync<BattleScenePresenter>().Forget(); })
                .AddTo(this);
        }
    }
}
