using ExampleProject.GameSystem;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.BaseUI
{
    public class BaseButton : MonoBehaviour
    {
        #region Fields

        Button button;


        #endregion

        #region Properties

        [ShowInInspector] protected Button ThisButton => button = button != null ? button : GetComponent<Button>();

        #endregion

        #region LifeCycle   

        protected virtual void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }
        protected virtual void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }

        #endregion

        #region Private Methods

        protected virtual void ListenerMethod()
        {
            SoundSystem.Instance.PlayUIClick();
            VibrationSystem.Instance.PlayVibration();
        }

        #endregion

        #region Public Methods



        #endregion
    }
}