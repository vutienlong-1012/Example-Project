using ExampleProject.Manager;
using ExampleProject.UI.BaseUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleProject.UI.HomePopup
{
    public class PlayButton : BaseButton
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
            GameManager.Instance.State = GameState.PlayingScene;
        }

        #endregion

        #region Public Methods



        #endregion
    }
}
