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
            //UIManager.Instance.settingPopup.
            //    SetOnStartShow(() => UIManager.Instance.homePopup.Hide()).
            //    SetOnStartHide(() => UIManager.Instance.homePopup.Show()).Show();
            UIManager.Instance.homePopup.SetOnCompleteHide(() =>
            {
                UIManager.Instance.settingPopup.SetOnCompleteHide(() =>
                {
                    UIManager.Instance.homePopup.Show();
                }).Show();
            }).Hide();
        }
    }
}