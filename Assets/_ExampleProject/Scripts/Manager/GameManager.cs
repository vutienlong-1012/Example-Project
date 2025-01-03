using Sirenix.OdinInspector;
using System.Collections;
using ExampleProject.Tools;
using UnityEngine;
using ExampleProject.Gameplay.Scenes;
using ExampleProject.UI.BaseUI.BasePopup;

namespace ExampleProject.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        #region Fields

        GameState state;

        #endregion

        #region Properties

        [ShowInInspector]
        public GameState State
        {
            get => state;
            set
            {
                state = value;
                ChangeState(value);
            }
        }
        UIManager UIManager => UIManager.instance;
        EventDispatcher EventDispatcher => EventDispatcher.Instance;
        FakeLoadController FakeLoadController => FakeLoadController.instance;
        MainHomeController MainHomeController => MainHomeController.instance;
        LoadSceneManager LoadSceneManager => LoadSceneManager.instance;
        GameplayController GameplayController => GameplayController.instance;
        #endregion

        #region LifeCycle   

        // Kick the game off with the first state
        void Start()
        {
            State = GameState.FakeLoadingMainScene;
        }

        #endregion

        #region Private Methods

        void ChangeState(GameState _state)
        {
            EventDispatcher.Dispatch(EventName.OnBeforeGameStateChange, state);
            switch (_state)
            {
                case GameState.FakeLoadingMainScene:
                    HandleFakeLoadingMainSceneState();
                    break;
                case GameState.MainScene:
                    HandleMainSceneState();
                    break;
                case GameState.PlayingScene:
                    HandlePlayingScene();
                    break;
            }
            Debug.Log("<color=yellow>Game State: </color>" + _state);
            EventDispatcher.Dispatch(EventName.OnAfterGameStateChange, state);
        }
        void HandleFakeLoadingMainSceneState()
        {
            FakeLoadController.Init();
            FakeLoadController.StartFakeLoad(() =>
            {
                State = GameState.MainScene;
            });
        }
        void HandleMainSceneState()
        {
            MainHomeController.Init();
        }
        void HandlePlayingScene()
        {

            GameplayController.Init();
        }

        #endregion

        #region Protected Methods



        #endregion

        #region Public Methods



        #endregion
    }

    public enum GameState
    {
        None,
        FakeLoadingMainScene,
        MainScene,
        PlayingScene,
    }
}