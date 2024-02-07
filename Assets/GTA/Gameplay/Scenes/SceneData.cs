using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using VTLTools.ResourceLoader;

namespace ExampleProject.Scenes
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneData"), InlineEditor]
    public class SceneData : ScriptableObject
    {
        #region Fields

        public SceneId id;
        public Object scene;

        #endregion

        #region Properties

         [SerializeField] public string sceneName;

        #endregion
    }

    public enum SceneId
    {
        None = 0,
        FakeLoading = 1,
        MainHome = 2,
        Gameplay = 3,
    }
}