using ExampleProject.Manager;
using ExampleProject.Tools;
using ExampleProject.UI.BaseUI.BasePopup;
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



        #endregion

        #region Public Methods

        public void Init()
        {
            UIManager.StackCamera(mainCam);
            UIManager.GetPopup(PopupId.HomePopup).Show();
        }

        #endregion
    }
}
