using DG.Tweening;
using ExampleProject.Scene;
using ExampleProject.UI.LoadingScenePopup;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VTLTools;

namespace ExampleProject
{
    public class LoadSceneManager : Singleton<LoadSceneManager>
    {
        [SerializeField] LoadingScenePopup loadingPopup;
        [SerializeField, ReadOnly]
        public SceneId CurrentScene
        {
            get; private set;
        }

        [SerializeField, ReadOnly] bool isUnloadingScene;

        public void LoadScene(SceneId _sceneID, Action _onComepleteLoading)
        {
            Debug.Log("<color=yellow>Loading scene: </color>" + _sceneID);
            GameManager.instance.State = GameState.LoadingNewScene;
            CurrentScene = _sceneID;
            loadingPopup.Show();

            StartCoroutine(_LoadScene());
            IEnumerator _LoadScene()
            {
                var _asyncOp = SceneManager.LoadSceneAsync(Scenes.GetData(CurrentScene).SceneName);
                while (!_asyncOp.isDone)
                {
                    loadingPopup.SetProgress(_asyncOp.progress);
                    yield return null;
                }
              
                loadingPopup.Hide();
                _onComepleteLoading?.Invoke();
                //GameManager.instance.State = GameState.PlayingMinigame;
                //LogManager.LogLevel(GetCurrentGameLevel, LevelDifficulty.Easy, 0, PassLevelStatus.Start, "");
            }
        }

        public void UnloadCurrentScene()
        {
            if (isUnloadingScene)
            {
                Debug.LogError("Dupplicate loading!!!!");
                return;
            }

            isUnloadingScene = true;
            //LogManager.LogLevel(GetCurrentGameLevel, LevelDifficulty.Easy, (int)timePlayCount.GetPlayTime(), PassLevelStatus.Pass, "");
            Debug.Log("<color=yellow>Unloading scene: </color>" + CurrentScene);
            //GameManager.instance.State = GameState.UnloadingMiniGame;

            loadingPopup.Show();

            StartCoroutine(_LoadScene());
            IEnumerator _LoadScene()
            {
                var _asyncOp = SceneManager.UnloadSceneAsync(Scenes.GetData(CurrentScene).SceneName);
                while (!_asyncOp.isDone)
                {
                    loadingPopup.SetProgress(_asyncOp.progress);
                    yield return null;
                }

                SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainHomeScene")); ;
                loadingPopup.Hide();
                //GameManager.instance.backHomeCount++;
                //GameManager.instance.State = GameState.BackToMainScene;
                //currentGameScene = MiniGameId.None;

                isUnloadingScene = false;
            }
        }

    }
}