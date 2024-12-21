using ExampleProject.Manager;
using ExampleProject.Tools;
using System;
using UnityEngine;

namespace ExampleProject.Gameplay.Scenes
{
    public class FakeLoadController : Singleton<FakeLoadController>
    {
        #region Fields

        [SerializeField] float fakeLoadTime;
        [SerializeField] float editorFakeLoadTime;
        [SerializeField] Camera mainCam;

        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods
        public void Init()
        {
            UIManager.instance.StackCamera(mainCam);
        }
        public void StartFakeLoad(Action _onComplete)
        {
#if UNITY_EDITOR
            LoadSceneManager.Instance.StartFakeLoadMainScene(SceneId.MainHome, _onComplete, editorFakeLoadTime);
#else
            LoadSceneManager.Instance.StartFakeLoadMainScene(SceneId.MainHome, _onComplete, fakeLoadTime);
#endif
        }

        #endregion
    }
}
