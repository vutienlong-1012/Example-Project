using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI
{
    public class HomePopup : PopupBase
    {
        [SerializeField, BoxGroup("Popup Reference")] protected Button settingButton;

        protected override void ButtonAddListener()
        {
            base.ButtonAddListener();
            settingButton.onClick.AddListener(SettingButtonOnClick);
        }

        protected override void ButtonRemoveListener()
        {
            base.ButtonRemoveListener();
            settingButton.onClick.RemoveListener(SettingButtonOnClick);
        }

        void SettingButtonOnClick()
        {
            UIManager.Instance.settingPopup.Show(
                                                _data: null,
                                                _isDoAnimation: true,
                                                _delay: 0,
                                                _actionOnStartShow: () => UIManager.Instance.homePopup.Hide(),
                                                _actionOnCompleteShow: null,
                                                _actionOnStartHide: () => UIManager.Instance.homePopup.Show(),
                                                _actionOnCompleteHide: null
                                                );
        }
    }
}