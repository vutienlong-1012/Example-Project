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

        UIManager UIManager => UIManager.instance;
        LoadSceneManager LoadSceneManager => LoadSceneManager.instance;

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods
        public void Init()
        {
            UIManager.StackCamera(mainCam);
            UserDataManager.FistTimePlay = DateTime.Now;
        }
        public void StartFakeLoad(Action _onComplete)
        {
#if UNITY_EDITOR
            LoadSceneManager.StartFakeLoadMainScene(SceneId.MainHome, _onComplete, editorFakeLoadTime);
#else
            LoadSceneManager.StartFakeLoadMainScene(SceneId.MainHome, _onComplete, fakeLoadTime);
#endif
        }

        #endregion
    }
}
