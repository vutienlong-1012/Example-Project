using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExampleProject.Tools;
using ExampleProject.GameSystem;

namespace ExampleProject.UI.SettingPopup
{
    public class VibrationToggle : BaseToggle
    {
        protected override void OnEnable()
        {
            ThisToggle.isOn = UserDataManager.IsVibrationOn;
            base.OnEnable();
        }

        protected override void ListenerMethod(bool _value)
        {
            VibrationSystem.Instance.SetVibration(_value);
            base.ListenerMethod(_value);
        }
    }
}