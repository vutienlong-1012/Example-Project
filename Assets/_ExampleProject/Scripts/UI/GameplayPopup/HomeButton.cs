using ExampleProject.Gameplay.Scenes;
using ExampleProject.Manager;
using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleProject.UI.GameplayPopup
{
    public class HomeButton : BaseButton
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods

        protected override void ListenerMethod()
        {
            base.ListenerMethod();
            LoadSceneManager.Instance.LoadScene(SceneId.MainHome, () =>
            {
                GameManager.Instance.State = GameState.MainScene;
            });
        }

        #endregion

        #region Public Methods



        #endregion
    }
}
