using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExampleProject.Manager;
using Sirenix.OdinInspector;
using ExampleProject.UI.BaseUI;
using ExampleProject.GameSystem;

namespace ExampleProject.UI.SettingPopup
{
    public class SoundToggle : BaseToggle
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region LifeCycle   

        protected override void OnEnable()
        {
            ThisToggle.isOn = UserDataManager.IsSoundOn;
            base.OnEnable();
        }

        #endregion

        #region Private Methods

        protected override void ListenerMethod(bool _value)
        {
            SoundSystem.Instance.SetSound(_value);
            base.ListenerMethod(_value);
        }

        #endregion

        #region Public Methods



        #endregion
    }
}    