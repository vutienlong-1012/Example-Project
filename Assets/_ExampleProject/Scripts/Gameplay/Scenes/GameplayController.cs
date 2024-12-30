using ExampleProject.Manager;
using ExampleProject.Tools;
using ExampleProject.UI.BaseUI.BasePopup;
using ExampleProject.UI.HomePopup;
using System;
using UnityEngine;

namespace ExampleProject.Gameplay.Scenes
{
    public class GameplayController : Singleton<GameplayController>
    {
        #region Fields

        [SerializeField] Camera mainCam;

        #endregion

        #region Properties

        LoadSceneManager LoadSceneManager => LoadSceneManager.instance;
        GameManager GameManager => GameManager.instance;
        UIManager UIManager => UIManager.instance;

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods

        void HideUnnecesaryPopup()
        {
            if (UIManager.IsHasPopup(PopupId.HomePopup, out HomePopup _home))
                _home.SetIsDoAnimation(false).Hide();
        }

        #endregion

        #region Public Methods

        public void Init()
        {
            UIManager.StackCamera(mainCam);
            HideUnnecesaryPopup();
            UIManager.GetPopup(PopupId.Gameplay).Show();

        }
        public void ExitGameplay()
        {
            LoadSceneManager.LoadScene(SceneId.MainHome, () =>
            {
                GameManager.State = GameState.MainScene;
            });
        }

        #endregion
    }
}
