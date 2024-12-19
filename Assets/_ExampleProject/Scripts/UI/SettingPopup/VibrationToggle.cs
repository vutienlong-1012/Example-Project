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
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region LifeCycle   

        protected override void OnEnable()
        {
            ThisToggle.isOn = UserDataManager.IsVibrationOn;
            base.OnEnable();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        protected override void ListenerMethod(bool _value)
        {
            VibrationSystem.Instance.SetVibration(_value);
            base.ListenerMethod(_value);
        }

        #endregion
    }
}