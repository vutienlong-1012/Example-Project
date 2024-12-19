using ExampleProject.UI.BaseUI.BasePopup;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.LoadingScenePopup
{
    public class LoadingScenePopup : BasePopup
    {
        #region Fields

        [SerializeField] Slider loadingSlider;
        [SerializeField] Text progressText;

        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void SetProgress(float _value)
        {
            loadingSlider.value = _value;
            //progressText.text = (Mathf.Clamp01(_value) * 100).ToString("N0") + "%";
        }

        #endregion
    }
}