using ExampleProject.UI;
using ExampleProject.UI.SharedAssets;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.LoadingScenePopup
{
    public class LoadingScenePopup : PopupBase
    {
        [SerializeField] Slider loadingSlider;
        [SerializeField] Text progressText;

        public void SetProgress(float _value)
        {
            loadingSlider.value = _value;
            //progressText.text = (Mathf.Clamp01(_value) * 100).ToString("N0") + "%";
        }
    }
}