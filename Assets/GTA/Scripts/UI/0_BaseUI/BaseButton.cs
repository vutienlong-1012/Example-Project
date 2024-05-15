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
        Button button;

        [ShowInInspector]
        protected Button ThisButton => button = button != null ? button : GetComponent<Button>();

        protected virtual void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }


        protected virtual void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }

        protected virtual void ListenerMethod()
        {
            SoundSystem.Instance.PlayUIClick();
            VibrationSystem.Instance.PlayVibration();
        }
    }
}