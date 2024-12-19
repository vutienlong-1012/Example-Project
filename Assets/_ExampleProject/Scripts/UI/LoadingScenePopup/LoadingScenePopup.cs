using ExampleProject.UI.BaseUI.BasePopup;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.LoadingScenePopup
{
    public class LoadingScenePopup : BasePopup
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