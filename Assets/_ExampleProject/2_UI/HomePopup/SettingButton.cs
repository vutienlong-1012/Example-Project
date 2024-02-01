using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleProject.UI.HomePopup
{
    public class SettingButton : BaseButton
    {
        protected override void ListenerMethod()
        {
            base.ListenerMethod();
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