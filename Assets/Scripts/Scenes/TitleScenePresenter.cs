using Cysharp.Threading.Tasks;
using MOB.Scenes.Presenter;

namespace Mob.Scenes.Title
{
    public sealed class TitleScenePresenter : ScenePresenterBase
    {
        public override UniTask InitializeAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}
