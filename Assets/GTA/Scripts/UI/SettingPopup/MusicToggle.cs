using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VTLTools;

namespace ExampleProject.UI
{
    public class MusicToggle : BaseToggle
    {
        protected override void OnEnable()
        {
            ThisToggle.isOn = UserDataManager.IsMusicOn;
            base.OnEnable();
        }

        protected override void ListenerMethod(bool _value)
        {
            MusicSystem.Instance.SetMusic(_value);
            base.ListenerMethod(_value);
        }
    }
}