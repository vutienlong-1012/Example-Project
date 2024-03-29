using ExampleProject.UI;
using ExampleProject.Scene;
using Sirenix.OdinInspector;
using System.Collections;
using VTLTools;
using UnityEngine;
using ExampleProject.UI.SharedAssets;
using ExampleProject.UI.HomePopup;
using ExampleProject.UI.LoadingScenePopup;

namespace ExampleProject
{
    public class GameManager : Singleton<GameManager>
    {
        GameState state;
        [ShowInInspector]
        public GameState State
        {
            get => state;
            set
            {
                state = value;
                EventDispatcher.Instance.Dispatch(EventName.OnBeforeGameStateChange, state);
                Debug.Log("<color=yellow>Game State: </color>" + State);
                switch (state)
                {
                    case GameState.FakeLoadingMainScene:
                        HandleFakeLoadingMainSceneState();
                        break;
                    case GameState.MainScene:
                        HandleMainSceneState();
                        break;
                    case GameState.LoadingNewScene:
                        HandleLoadingNewSceneState();
                        break;
                    case GameState.PlayingScene:
                        HandlePlayingScene();
                        break;
                }
                EventDispatcher.Instance.Dispatch(EventName.OnAfterGameStateChange, state);
            }
        }

        UIManager UIManager => UIManager.instance;

        // Kick the game off with the first state
        void Start()
        {
            State = GameState.FakeLoadingMainScene;
        }

        void HandleFakeLoadingMainSceneState()
        {
            FakeLoadMainScene.instance.StartFakeLoad();
        }

        void HandleMainSceneState()
        {
            UIManager.instance.SpawnPopup(PopupId.HomePopup).Show();
        }

        void HandleLoadingNewSceneState()
        {

        }

        void HandlePlayingScene()
        {

        }
    }

    public enum GameState
    {
        None,
        FakeLoadingMainScene,
        MainScene,
        LoadingNewScene,
        PlayingScene,
    }
}