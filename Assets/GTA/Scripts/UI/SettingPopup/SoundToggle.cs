using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VTLTools;
using Sirenix.OdinInspector;
using ExampleProject.UI.BaseUI;

namespace ExampleProject.UI.SettingPopup
{
    public class SoundToggle : BaseToggle
    {
        protected override void OnEnable()
        {
            ThisToggle.isOn = UserDataManager.IsSoundOn;
            base.OnEnable();
        }

        protected override void ListenerMethod(bool _value)
        {
            SoundSystem.Instance.SetSound(_value);
            base.ListenerMethod(_value);
        }
    }
}    