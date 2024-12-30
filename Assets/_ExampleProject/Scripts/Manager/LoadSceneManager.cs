using DG.Tweening;
using ExampleProject.UI;
using ExampleProject.UI.LoadingScenePopup;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExampleProject.Tools;
using ExampleProject.Gameplay.Scenes;
using ExampleProject.UI.BaseUI.BasePopup;

namespace ExampleProject.Manager
{
    public class LoadSceneManager : Singleton<LoadSceneManager>
    {
        #region Fields

        [SerializeField, ReadOnly] LoadingScenePopup loadingPopup;
        [SerializeField, ReadOnly] bool isUnloadingScene;
        [SerializeField, ReadOnly] bool isLoadingGameplayScene;

        #endregion

        #region Properties

        [ShowInInspector, ReadOnly]
        public SceneId CurrentSceneId
        {
            get; private set;
        }

        UIManager UIManager => UIManager.instance;
        #endregion

        #region LifeCycle    


        #endregion

        #region Private Methods


        #endregion

        #region Public Methods

        public void StartFakeLoadMainScene(SceneId _sceneID, Action _onCompleteAction, float _fakeTime)
        {
            loadingPopup = (LoadingScenePopup)UIManager.GetPopup(PopupId.LoadingScenePopup);
            StartCoroutine(_IEFakeLoadAsynchronously());

            IEnumerator _IEFakeLoadAsynchronously()
            {
                AsyncOperation _operation = null;
                float _currentFakeLoadTime = _fakeTime;
                float _progress = 0;

                while (_progress < 1)
                {
                    _currentFakeLoadTime -= Time.deltaTime;
                    _progress = 1 - (_currentFakeLoadTime / _fakeTime);
                    loadingPopup.SetProgress(_progress);

                    if (_progress >= 0.3 && !isLoadingGameplayScene)
                    {
                        isLoadingGameplayScene = true;
                        _operation = SceneManager.LoadSceneAsync(Scenes.GetResourceData(_sceneID).SceneName);
                        _operation.allowSceneActivation = false;
                    }

                    yield return null;
                }

                _operation.allowSceneActivation = true;
                _operation.completed += (AsyncOperation op) =>
                {
                    SceneManager.SetActiveScene(Scenes.GetUnityScene(_sceneID));
                    loadingPopup.Hide();
                    _onCompleteAction?.Invoke();
                };
            }
        }
        public void LoadScene(SceneId _sceneID, Action _onCompleteLoading)
        {
            Debug.Log("<color=yellow>Loading scene: </color>" + _sceneID);
            CurrentSceneId = _sceneID;
            loadingPopup = (LoadingScenePopup)UIManager.GetPopup(PopupId.LoadingScenePopup);
            loadingPopup.Show();

            StartCoroutine(_AsyncLoad());

            IEnumerator _AsyncLoad()
            {
                AsyncOperation _asyncLoad;

                _asyncLoad = SceneManager.LoadSceneAsync(Scenes.GetResourceData(_sceneID).SceneName);
                while (!_asyncLoad.isDone)
                {
                    loadingPopup.SetProgress(_asyncLoad.progress);
                    yield return null;
                }
                loadingPopup.Hide();
                _onCompleteLoading?.Invoke();
            }
        }
        public void UnloadCurrentScene()
        {
            if (isUnloadingScene)
            {
                Debug.LogError("Duplicate unloading!!!!");
                return;
            }

            isUnloadingScene = true;
            Debug.Log("<color=yellow>Unloading scene: </color>" + CurrentSceneId);

            loadingPopup.Show();

            StartCoroutine(_LoadScene());
            IEnumerator _LoadScene()
            {
                var _asyncOp = SceneManager.UnloadSceneAsync(Scenes.GetResourceData(CurrentSceneId).SceneName);
                while (!_asyncOp.isDone)
                {
                    loadingPopup.SetProgress(_asyncOp.progress);
                    yield return null;
                }

                SceneManager.SetActiveScene(Scenes.GetUnityScene(SceneId.MainHome));
                loadingPopup.Hide();
                isUnloadingScene = false;
            }
        }

        #endregion
    }
}