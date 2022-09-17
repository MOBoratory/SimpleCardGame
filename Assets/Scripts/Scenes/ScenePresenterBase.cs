using System;
using Cysharp.Threading.Tasks;
using MOB.CommonUI.Presenters;
using MOB.Services;
using UnityEngine;

namespace MOB.Scenes.Presenter
{
    /// <summary>
    ///     シーンPresenter 基底クラス
    /// </summary>
    public abstract class ScenePresenterBase : MonoBehaviour
    {
        protected readonly Lazy<SceneService> sceneService = new(() => ServiceManager.GetService<SceneService>());

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
        ///     シーン初期化
        /// </summary>
        public abstract UniTask InitializeAsync();

        /// <summary>
        ///     シーンフェードイン開始前
        /// </summary>
        public virtual UniTask BeforeSceneFadeInAsync()
        {
            return UniTask.CompletedTask;
        }

        /// <summary>
        ///     シーンフェードアウト開始前
        /// </summary>
        public virtual UniTask BeforeSceneFadeOutAsync()
        {
            return UniTask.CompletedTask;
        }

        /// <summary>
        ///     シーンフェードイン完了時
        /// </summary>
        public virtual UniTask OnSceneFadeInCompleteAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}
