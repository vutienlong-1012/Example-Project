using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExampleProject.Tools;
using ExampleProject.Manager;
using ExampleProject.UI.BaseUI.BasePopup;
using ExampleProject.UI.LoadingScenePopup;


namespace ExampleProject.Gameplay.Scenes
{
    public class FakeLoadMainScene : Singleton<FakeLoadMainScene>
    {
        #region Fields

        [SerializeField] float fakeLoadTime;
        [SerializeField] float editorLoadTime;
        [SerializeField, ReadOnly] LoadingScenePopup loadingScenePopup;
        //[SerializeField] bool isShowedFirstAOA = false;
        bool isLoadingGameplayScene;
        bool isAlreadyCalledAOA;

        #endregion

        #region Properties

        UIManager UIManager => UIManager.instance;

        #endregion

        #region LifeCycle   

        #endregion

        #region Private Methods

        IEnumerator LoadAsynchronously()
        {
            AsyncOperation _operation = null;
            float _currentFakeLoadTime = fakeLoadTime;
            float _progress = 0;
            while (_progress < 1)
            {
                _currentFakeLoadTime -= Time.deltaTime;
                _progress = 1 - (_currentFakeLoadTime / fakeLoadTime);
                loadingScenePopup.SetProgress(_progress);

                if (_progress >= 0.55 && !isAlreadyCalledAOA)
                {
                    isAlreadyCalledAOA = true;
                    //if (CC_Interface.current.isJustLaunch)
                    //{
                    //    CC_Interface.current.isJustLaunch = false;
                    //    CC_Interface.current.ShowAppOpenAd();

                    //}
                }

                if (_progress >= 0.3 && !isLoadingGameplayScene)
                {
                    _operation = SceneManager.LoadSceneAsync(Scenes.GetResourceData(SceneId.MainHome).SceneName);
                    _operation.allowSceneActivation = false;
                    isLoadingGameplayScene = true;
                }

                yield return null;
            }

            _operation.allowSceneActivation = true;
            _operation.completed += (AsyncOperation op) =>
            {
                GameManager.instance.State = GameState.MainScene;
                SceneManager.SetActiveScene(Scenes.GetUnityScene(SceneId.MainHome));
                loadingScenePopup.Hide();
            };
        }

        #endregion

        #region Protected Methods

        #endregion

        #region Public Methods

        public void StartFakeLoad()
        {
            Application.targetFrameRate = 60;
#if UNITY_EDITOR
            fakeLoadTime = editorLoadTime;
#endif
            loadingScenePopup = (LoadingScenePopup)UIManager.GetPopup(PopupId.LoadingScenePopup);
            StartCoroutine(LoadAsynchronously());
        }

        #endregion


    }
}