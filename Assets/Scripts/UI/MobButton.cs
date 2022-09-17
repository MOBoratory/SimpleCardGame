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

        private void Awake()
        {
            _button ??= GetComponent<Button>();
        }
    }
}
