using Cysharp.Threading.Tasks;

namespace MOB.HoRogue.Scenes
{
    public interface IScene
    {
        UniTask InitializeCoreAsync();
        UniTask InitializeAsync();
        UniTask OnSceneFadeInCompleteAsync();
    }
}
