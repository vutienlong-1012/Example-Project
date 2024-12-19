using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using ExampleProject.Tools;

namespace ExampleProject.Gameplay.Scenes
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneData"), InlineEditor]
    public class SceneData : ScriptableObject
    {
        #region Fields

        public SceneId id;
        public Object scene;

        #endregion

        #region Properties

        [ShowInInspector] public string SceneName => scene.name;

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