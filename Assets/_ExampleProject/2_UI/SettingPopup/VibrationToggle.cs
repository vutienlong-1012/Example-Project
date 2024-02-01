using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VTLTools;

namespace ExampleProject.UI
{
    public class VibrationToggle : BaseToggle
    {
        protected override void OnEnable()
        {
            ThisToggle.isOn = UserDataManager.IsVibrationOn;
            base.OnEnable();
        }

        protected override void ListenerMethod(bool arg0)
        {
            VibrationSystem.Instance.ToggeVibration();
            base.ListenerMethod(arg0);
        }
    }
}