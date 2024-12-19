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

namespace ExampleProject.Manager
{
    public class LoadSceneManager : Singleton<LoadSceneManager>
    {
        #region Fields

        [SerializeField] float fakeLoadTime;
        [SerializeField] float editorLoadTime;
        [SerializeField, ReadOnly] LoadingScenePopup loadingPopup;
        [SerializeField, ReadOnly] bool isUnloadingScene;
        [SerializeField, ReadOnly] bool isLoadingGamplayScene;
        [SerializeField, ReadOnly] bool isAlreadyCalledAOA;

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

        public void LoadScene(SceneId _sceneID, Action _onComepleteLoading)
        {
            Debug.Log("<color=yellow>Loading scene: </color>" + _sceneID);
            GameManager.instance.State = GameState.LoadingNewScene;
            CurrentSceneId = _sceneID;
            loadingPopup = (LoadingScenePopup)UIManager.GetPopup(PopupId.LoadingScenePopup);
            loadingPopup.Show();

            StartCoroutine(AsyncLoadBeaty(_onComepleteLoading));
        }


        IEnumerator AsyncLoadBeaty(Action _onCompleteAction)
        {
            AsyncOperation _asyncLoad;
            float _loadProgress;
            GameObject _loadController = new GameObject("LoadController");
            float _apprLoadTime = 0.25f;
            float _apprLoadTimeMin = 0.2f;
            float _apprLoadTimeMax = 3f;

            float _steps = 25f;
            float _iStep = 1f / _steps;
            float _loadTime = 0.0f;
            _loadProgress = 0;

            loadingPopup = (LoadingScenePopup)UIManager.GetPopup(PopupId.LoadingScenePopup);
            loadingPopup.Show();
            loadingPopup.SetProgress(_loadProgress);
            yield return new WaitForSeconds(0.2f);

            _asyncLoad = SceneManager.LoadSceneAsync(Scenes.GetResourceData(CurrentSceneId).SceneName);
            Debug.Log(Scenes.GetResourceData(CurrentSceneId).SceneName);
            _asyncLoad.allowSceneActivation = false;
            float _lastTime = Time.time;

            while (_loadProgress < 0.99f || _asyncLoad.progress < 0.90f)
            {
                _loadTime += (Time.time - _lastTime);
                _lastTime = Time.time;
                _loadProgress = Mathf.Clamp01(_loadProgress + _iStep);
                loadingPopup.SetProgress(_loadProgress);

                if (_loadTime >= 0.5f * _apprLoadTime && (_asyncLoad.progress < 0.5f))
                {
                    _apprLoadTime *= 1.1f;
                    _apprLoadTime = Mathf.Min(_apprLoadTimeMax, _apprLoadTime);
                }
                else if (_loadTime >= 0.5f * _apprLoadTime && (_asyncLoad.progress > 0.5f))
                {
                    _apprLoadTime /= 1.1f;
                    _apprLoadTime = Mathf.Max(_apprLoadTimeMin, _apprLoadTime);
                }

                //_progresUpdate?.Invoke(_loadProgress);
                // Debug.Log("waite scene: " + _loadTime + "; ao.progress : " + ao.progress + " ;_loadProgress" + _loadProgress);
                yield return new WaitForSeconds(_apprLoadTime / _steps);
            }

            yield return new WaitForSeconds(1f);
            _asyncLoad.allowSceneActivation = true;
            yield return new WaitWhile(() => { return _loadController; }); // wait while gameobject exist
            loadingPopup.Hide();
            _onCompleteAction?.Invoke();
        }
        public void StartFakeLoadMainScene(Action _onCompleteAction)
        {
#if UNITY_EDITOR
            fakeLoadTime = editorLoadTime;
#endif
            loadingPopup = (LoadingScenePopup)UIManager.GetPopup(PopupId.LoadingScenePopup);
            StartCoroutine(_IEFakeLoadAsynchronously());

            IEnumerator _IEFakeLoadAsynchronously()
            {
                AsyncOperation _operation = null;
                float _currentFakeLoadTime = fakeLoadTime;
                float _progess = 0;
                while (_progess < 1)
                {
                    _currentFakeLoadTime -= Time.deltaTime;
                    _progess = 1 - (_currentFakeLoadTime / fakeLoadTime);
                    loadingPopup.SetProgress(_progess);

                    if (_progess >= 0.55 && !isAlreadyCalledAOA)
                    {
                        isAlreadyCalledAOA = true;
                        //if (CC_Interface.current.isJustLaunch)
                        //{
                        //    CC_Interface.current.isJustLaunch = false;
                        //    CC_Interface.current.ShowAppOpenAd();

                        //}
                    }

                    if (_progess >= 0.3 && !isLoadingGamplayScene)
                    {
                        _operation = SceneManager.LoadSceneAsync(Scenes.GetResourceData(SceneId.MainHome).SceneName);
                        _operation.allowSceneActivation = false;
                        isLoadingGamplayScene = true;
                    }

                    yield return null;
                }

                _operation.allowSceneActivation = true;
                _operation.completed += (AsyncOperation op) =>
                {
                    GameManager.instance.State = GameState.MainScene;
                    SceneManager.SetActiveScene(Scenes.GetUnityScene(SceneId.MainHome));
                    loadingPopup.Hide();
                    _onCompleteAction?.Invoke();
                };
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
            Debug.Log("<color=yellow>Unloading scene: </color>" + CurrentSceneId);
            //GameManager2.instance.State = GameState.UnloadingMiniGame;

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
                //GameManager2.instance.backHomeCount++;
                //GameManager2.instance.State = GameState.BackToMainScene;
                //currentGameScene = MiniGameId.None;

                isUnloadingScene = false;
            }
        }
        #endregion
    }
}