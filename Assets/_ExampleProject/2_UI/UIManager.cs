using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

namespace ExampleProject.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] public HomePopup.HomePopup homePopup;
        [SerializeField] public SettingPopup.SettingPopup settingPopup;

        private void Start()
        {
            //homePopup.PreviewHide();
            //settingPopup.PreviewHide();
            homePopup.Show();
            //homePopup.Show();
        }
    }
}