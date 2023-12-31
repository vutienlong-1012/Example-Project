using ExampleProject.UI;
using ExampleProject.Scene;
using Sirenix.OdinInspector;
using System.Collections;
using VTLTools;
using UnityEngine;

namespace ExampleProject
{
    public class GameManager : Singleton<GameManager>
    {
        private GameState _state;
        [ShowInInspector]
        public GameState State
        {
            get => _state;
            set
            {
                _state = value;
                EventDispatcher.Instance.Dispatch(EventName.OnBeforeFightStateChange, _state);
                Debug.Log(State);
                switch (_state)
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
                EventDispatcher.Instance.Dispatch(EventName.OnAfterFightStateChange, _state);
            }
        }


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