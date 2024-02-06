using ExampleProject.UI.BaseUI;
using ExampleProject.UI.SharedAssets;
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
            uIManager.GetPopup(PopupId.HomePopup).SetOnCompleteHide(() =>
            {
                uIManager.SpawnPopup(PopupId.SettingPopup).SetOnCompleteHide(() =>
                {
                    uIManager.SpawnPopup(PopupId.HomePopup).Show();
                }).Show();
            }).Hide(); ;
        }
    }
}