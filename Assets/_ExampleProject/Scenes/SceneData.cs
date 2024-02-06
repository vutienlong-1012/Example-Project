using Sirenix.OdinInspector;
using UnityEngine;
using VTLTools.ResourceLoader;

namespace ExampleProject.Scene
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneData"), InlineEditor]
    public class SceneData : ScriptableObject
    {
        public SceneId id;
        [ShowInInspector]
        public string SceneName
        {
            get
            {
                if (scene != null)
                    return scene.name;
                return "";
            }
        }
        public Object scene;
    }

    public enum SceneId
    {
        None = 0,
        FakeLoading = 1,
        MainHome = 2,
    }
}