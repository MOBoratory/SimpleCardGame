using System;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using MOB.CommonUI.Presenters;
using MOB.HoRogue.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace MOB.Services
{
    public class SceneService : IService
    {
        /// <summary>
        ///     シーンをロードします
        /// </summary>
        /// <typeparam name="TScene">遷移先のシーン型</typeparam>
        /// <returns>ロードとシーン初期化の完了</returns>
        public async UniTask<TScene> LoadSceneAsync<TScene>(LoadSceneMode loadSceneMode = LoadSceneMode.Single)
            where TScene : Component, IScene
        {
            if (loadSceneMode == LoadSceneMode.Single)
            {
                // フェードアウト
                CommonUIScenePresenter.Instance.Value.PlayFadeOut();
                var enterDurations = CommonUIScenePresenter.Instance.Value.EnterDurations;
                await UniTask.Delay(TimeSpan.FromSeconds(enterDurations.delay));
                await UniTask.Delay(TimeSpan.FromSeconds(enterDurations.duration));
            }

            using (var sb = ZString.CreateStringBuilder())
            {
                var sceneType = typeof(TScene);
                sb.Append(sceneType.Name.Replace("ScenePresenter", string.Empty));
                await SceneManager.LoadSceneAsync(sb.ToString(), loadSceneMode).ToUniTask();
            }

            // ロード完了後、シーンを初期化
            var scenePresenter = Object.FindObjectOfType<TScene>();
            await scenePresenter.InitializeCoreAsync();
            await scenePresenter.InitializeAsync();

            if (loadSceneMode == LoadSceneMode.Single)
            {
                // フェードイン
                CommonUIScenePresenter.Instance.Value.PlayFadeIn();
                // 完了までにかかる秒数待機する
                var exitDurations = CommonUIScenePresenter.Instance.Value.ExitDurations;
                await UniTask.Delay(TimeSpan.FromSeconds(exitDurations.delay));
                await UniTask.Delay(TimeSpan.FromSeconds(exitDurations.duration));

                await scenePresenter.OnSceneFadeInCompleteAsync();
            }

            return scenePresenter;
        }
    }
}
