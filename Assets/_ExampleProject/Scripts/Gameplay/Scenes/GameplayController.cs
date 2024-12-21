using ExampleProject.Manager;
using ExampleProject.Tools;
using ExampleProject.UI.BaseUI.BasePopup;
using System.Collections.Generic;

namespace ExampleProject.Gameplay.Scenes
{
    public class GameplayController : Singleton<GameplayController>
    {
        #region Fields



        #endregion

        #region Properties

        LoadSceneManager LoadSceneManager => LoadSceneManager.instance;
        GameManager GameManager => GameManager.instance;
        UIManager UIManager => UIManager.instance;

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Init()
        {
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
