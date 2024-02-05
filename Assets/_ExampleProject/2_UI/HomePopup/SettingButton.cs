using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleProject.UI.HomePopup
{
    public class SettingButton : BaseButton
    {
        UIManager uIManager => UIManager.Instance;
        protected override void ListenerMethod()
        {
            base.ListenerMethod();
            uIManager.GetPopup(uIManager.homePopup).SetOnCompleteHide(() =>
            {
                uIManager.SpawnPopup(uIManager.settingPopup).SetOnCompleteHide(() =>
                {
                    uIManager.SpawnPopup(uIManager.homePopup).Show();
                }).Show();
            }).Hide(); ;
        }
    }
}