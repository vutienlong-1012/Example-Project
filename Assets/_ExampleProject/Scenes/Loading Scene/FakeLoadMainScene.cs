using ExampleProject.UI.LoadingScenePopup;
using ExampleProject;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VTLTools;

namespace ExampleProject.Scene
{
    public class FakeLoadMainScene : Singleton<FakeLoadMainScene>
    {
        [SerializeField] float fakeLoadTime;
        [SerializeField] float editorLoadTime;
        [SerializeField] LoadingScenePopup loadingScenePopup;
        //[SerializeField] bool isShowedFirstAOA = false;
        public void StartFakeLoad()
        {
            Application.targetFrameRate = 60;
#if UNITY_EDITOR
            fakeLoadTime = editorLoadTime;
#endif
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
                    _operation = SceneManager.LoadSceneAsync(1);
                    _operation.allowSceneActivation = false;
                    isLoadingGamplayScene = true;
                }

                yield return null;
            }

            _operation.allowSceneActivation = true;
            _operation.completed += (AsyncOperation op) =>
            {
                //GameManager.instance.State = GameState.MainScene;
                loadingScenePopup.Hide();
            };
        }
    }
}