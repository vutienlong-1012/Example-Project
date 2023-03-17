using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

namespace ExampleProject.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] public HomePopup homePopup;
        [SerializeField] public SettingPopup settingPopup;

        private void Start()
        {
            homePopup.PreviewHide();
            settingPopup.PreviewHide();
            ShowPopup(homePopup);
            HidePopup(settingPopup);
        }

        [Button]
        public void ShowPopup(PopupBase _popup, object _data = null, float _delay = 0f, Action _actionOnStartShow = null, Action _actionOnCompleteShow = null, Action _actionOnStartHide = null, Action _actionOnCompleteHide = null)
        {
            _popup.Show(null, _delay, _actionOnStartShow, _actionOnCompleteShow, _actionOnStartHide, _actionOnCompleteHide);
        }

        [Button]
        public void HidePopup(PopupBase _popup)
        {
            _popup.Hide();
        }
    }
}