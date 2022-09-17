using System;
using Cysharp.Threading.Tasks;
using MOB.HoRogue.CommonUI.Presenters;
using MOB.HoRogue.Scenes;
using MOB.HoRogue.Services;
using Mob.Scenes.Title;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Mob.Enviroment
{
    public static class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void OnBeforeSplashScreen()
        {
            Debug.Log($"{nameof(OnBeforeSplashScreen)}");

            // タイトルシーンから自動開始する設定
            const string startScenePath = "Assets/Scenes/Title.unity";
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(startScenePath);
            EditorSceneManager.playModeStartScene = sceneAsset;

            // ゲーム全体の初期化を投げっぱなす
            InitializeGameAsync<TitleScenePresenter>().Forget();
        }

        public static async UniTask InitializeGameAsync<TInitialScene>()
            where TInitialScene : ScenePresenterBase
        {
            Debug.Log($"{nameof(InitializeGameAsync)}...");

            // あらかじめ必要なServiceを追加しておく
            // NOTE: サービスを追加する場合はServiceBundleに追記する
            foreach (var type in ServiceBundle.GetServiceTypes())
            {
                var service = Activator.CreateInstance(type) as IService;
                ServiceManager.AddService(service);
            }

            // CommonUIを作っておく (Additive Scene)
            var sceneService = ServiceManager.GetService<SceneService>();
            var commonUI = await sceneService.LoadSceneAsync<CommonUIScenePresenter>(LoadSceneMode.Additive);
            commonUI.HideUI();

            // 初回は手動で初期化開始
            var initialScene = Object.FindObjectOfType<TInitialScene>();
            await initialScene.InitializeCoreAsync();
            await initialScene.InitializeAsync();
            // 初期化完了後、手動フェードイン
            commonUI.PlayFadeIn();
        }
    }
}
