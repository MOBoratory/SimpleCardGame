using System;
using Com.LuisPedroFonseca.ProCamera2D;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using MOB.HoRogue.Scenes;
using MOB.Scenes.Presenter;
using TMPro;
using UnityEngine;

namespace MOB.CommonUI.Presenters
{
    /// <summary>
    ///     汎用UIシーン Presenter
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class CommonUIScenePresenter : ScenePresenterBase, IScene
    {
        // TODO: 作成前に呼ばれたらどうするか
        public static readonly Lazy<CommonUIScenePresenter> Instance = new(() =>
            FindObjectOfType<CommonUIScenePresenter>());

        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private TMP_Text sceneNameText;
        [SerializeField] private TMP_Text userMoneyText;

        [SerializeField] private Camera uiCamera;

        [SerializeField] private Camera transitionCamera;
        [SerializeField] private ProCamera2DTransitionsFX transitionsFX;

        public (float duration, float delay) EnterDurations =>
            (duration: transitionsFX.DurationEnter, delay: transitionsFX.DelayEnter);

        public (float duration, float delay) ExitDurations =>
            (duration: transitionsFX.DurationExit, delay: transitionsFX.DelayExit);

        private void OnValidate()
        {
            if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        }

        public override async UniTask InitializeAsync()
        {
            DontDestroyOnLoad(this);

            // 最前面に表示する
            transitionCamera.depth = 100;
            // CommonUICameraはTransitionの一つ後ろ
            uiCamera.depth = 99;
        }

        public void ShowUI()
        {
            canvasGroup.alpha = 1;
            gameObject.SetActive(true);
        }

        public void HideUI()
        {
            canvasGroup.alpha = 0;
        }

        public void PlayFadeIn()
        {
            transitionsFX.TransitionEnter();
        }

        public void PlayFadeOut()
        {
            transitionsFX.TransitionExit();
        }

        public void SetSceneName(string sceneName)
        {
            sceneNameText.text = sceneName;
        }

        public void SetUserMoney(int money)
        {
            userMoneyText.text = ZString.Concat("Money: ", money);
        }
    }
}
