using ExampleProject.UI.LoadingScenePopup;
using ExampleProject;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VTLTools;
using ExampleProject.UI;
using ExampleProject.UI.SharedAssets;

namespace ExampleProject.Scene
{
    public class FakeLoadMainScene : Singleton<FakeLoadMainScene>
    {
        [SerializeField] float fakeLoadTime;
        [SerializeField] float editorLoadTime;
        [SerializeField, ReadOnly] LoadingScenePopup loadingScenePopup;
        //[SerializeField] bool isShowedFirstAOA = false;

        UIManager UIManager => UIManager.instance;
        public void StartFakeLoad()
        {
            Application.targetFrameRate = 60;
#if UNITY_EDITOR
            fakeLoadTime = editorLoadTime;
#endif
            loadingScenePopup = (LoadingScenePopup)UIManager.SpawnPopup(PopupId.LoadingScenePopup);
            StartCoroutine(LoadAsynchronously());
        }

        bool isLoadingGamplayScene;
        bool isAlreadyCalledAOA;
        IEnumerator LoadAsynchronously()
        {
            AsyncOperation _operation = null;
            float _currentFakeLoadTime = fakeLoadTime;
            float _progess = 0;
            while (_progess < 1)
            {
                _currentFakeLoadTime -= Time.deltaTime;
                _progess = 1 - (_currentFakeLoadTime / fakeLoadTime);
                loadingScenePopup.SetProgress(_progess);

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
                loadingScenePopup.Hide();
            };
        }
    }
}