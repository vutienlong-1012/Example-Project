using ExampleProject;
using ExampleProject.GameSystem;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.BaseUI
{
    public class BaseToggle : MonoBehaviour
    {
        Toggle toggle;

        [ShowInInspector]
        protected Toggle ThisToggle => toggle = toggle != null ? toggle : GetComponent<Toggle>();

        protected virtual void OnEnable()
        {
            ThisToggle.onValueChanged.AddListener(ListenerMethod);
        }


        protected virtual void OnDisable()
        {
            ThisToggle.onValueChanged.RemoveListener(ListenerMethod);
        }

        protected virtual void ListenerMethod(bool _value)
        {
            SoundSystem.Instance.PlayUIClick();
            VibrationSystem.Instance.PlayVibration();
        }
    }
}