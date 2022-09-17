using System;
using Cysharp.Threading.Tasks;
using MOB.HoRogue.CommonUI.Presenters;
using MOB.HoRogue.Services;
using UnityEngine;

namespace MOB.HoRogue.Scenes
{
    /// <summary>
    /// シーンPresenter 基底クラス
    /// </summary>
    public abstract class ScenePresenterBase : MonoBehaviour
    {
        protected readonly Lazy<SceneService> sceneService = new Lazy<SceneService>(() => ServiceManager.GetService<SceneService>());

        protected CommonUIScenePresenter commonUI;

        public async UniTask InitializeCoreAsync()
        {
            commonUI = FindObjectOfType<CommonUIScenePresenter>();
            var sceneName = GetType()
                .Name
                .Replace("ScenePresenter", string.Empty);
            commonUI.SetSceneName(sceneName);
        }

        /// <summary>
        /// シーン初期化
        /// </summary>
        public abstract UniTask InitializeAsync();

        /// <summary>
        /// シーンフェードイン開始前
        /// </summary>
        public virtual UniTask BeforeSceneFadeInAsync() => UniTask.CompletedTask;
        /// <summary>
        /// シーンフェードアウト開始前
        /// </summary>
        public virtual UniTask BeforeSceneFadeOutAsync() => UniTask.CompletedTask;

        /// <summary>
        /// シーンフェードイン完了時
        /// </summary>
        public virtual UniTask OnSceneFadeInCompleteAsync() => UniTask.CompletedTask;
    }
}
