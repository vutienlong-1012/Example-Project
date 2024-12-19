using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExampleProject.Tools;
using ExampleProject.GameSystem;

namespace ExampleProject.UI.SettingPopup
{
    public class MusicToggle : BaseToggle
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region LifeCycle   

        protected override void OnEnable()
        {
            ThisToggle.isOn = UserDataManager.IsMusicOn;
            base.OnEnable();
        }

        #endregion

        #region Private Methods

        protected override void ListenerMethod(bool _value)
        {
            MusicSystem.Instance.SetMusic(_value);
            base.ListenerMethod(_value);
        }

        #endregion

        #region Public Methods



        #endregion
    }
}