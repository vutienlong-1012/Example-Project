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

        protected override void ListenerMethod(bool arg0)
        {
            MusicSystem.Instance.ToggeMusic();
            base.ListenerMethod(arg0);
        }
    }
}