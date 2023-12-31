using ExampleProject.Scene;
using ExampleProject.UI.LoadingScenePopup;
using Sirenix.OdinInspector;
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

        public void LoadMiniGameScene(SceneId _sceneID)
        {

        }

        public void UnloadCurrentMiniGameScene()
        {

        }

    }
}