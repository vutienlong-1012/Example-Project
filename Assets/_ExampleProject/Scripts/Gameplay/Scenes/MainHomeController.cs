using ExampleProject.Manager;
using ExampleProject.Tools;
using ExampleProject.UI.BaseUI.BasePopup;
using ExampleProject.UI.GameplayPopup;
using ExampleProject.UI.HomePopup;
using UnityEngine;

namespace ExampleProject.Gameplay.Scenes
{
    public class MainHomeController : Singleton<MainHomeController>
    {
        #region Fields

        [SerializeField] Camera mainCam;

        #endregion

        #region Properties

        UIManager UIManager => UIManager.instance;

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods

        void HideUnnecesaryPopup()
        {
            if (UIManager.IsHasPopup(PopupId.Gameplay, out GameplayPopup _gameplay))
                _gameplay.SetIsDoAnimation(false).Hide();
        }

        #endregion

        #region Public Methods

        public void Init()
        {
            UIManager.StackCamera(mainCam);
            HideUnnecesaryPopup();
            UIManager.GetPopup(PopupId.HomePopup).Show();
        }

        #endregion
    }
}
