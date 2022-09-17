using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Mob.UI
{
    /// <summary>
    /// MOB Button
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class MobButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public IObservable<Unit> OnClickAsObservable => _button.OnClickAsObservable();
        public IObservable<Unit> OnClickThrottleFirstAsObservable => _button.OnClickAsObservable().ThrottleFirstFrame(1);

        private void Awake()
        {
            _button ??= GetComponent<Button>();
        }

        public void SetInteractable(bool interactable) => _button.interactable = interactable;
    }
}
