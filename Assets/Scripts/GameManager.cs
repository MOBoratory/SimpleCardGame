using UniRx;

namespace Mob
{
    /// <summary>
    ///     ゲームマネージャ
    /// </summary>
    public static class GameManager
    {
        public static MessageBroker MessageBroker { get; } = new();
    }
}
