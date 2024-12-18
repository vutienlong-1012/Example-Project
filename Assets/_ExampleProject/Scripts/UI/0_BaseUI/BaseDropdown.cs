using ExampleProject.GameSystem;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ExampleProject.UI.BaseUI
{
    public class BaseDropdown : MonoBehaviour, IPointerDownHandler
    {
        Dropdown dropdown;

        [ShowInInspector]
        protected Dropdown ThisDropdown => dropdown = dropdown != null ? dropdown : GetComponent<Dropdown>();

        protected virtual void OnEnable()
        {
            ThisDropdown.onValueChanged.AddListener(ListenerMethod);
        }


        protected virtual void OnDisable()
        {
            ThisDropdown.onValueChanged.RemoveListener(ListenerMethod);
        }

        protected virtual void ListenerMethod(int _value)
        {
            SoundSystem.Instance.PlayUIClick();
            VibrationSystem.Instance.PlayVibration();
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            SoundSystem.Instance.PlayUIClick();
            VibrationSystem.Instance.PlayVibration();
        }
    }
}