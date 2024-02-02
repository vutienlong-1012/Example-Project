using ExampleProject.UI.SharedAssets;
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
    }
}