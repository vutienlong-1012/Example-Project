using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VTLTools.ResourceAsset
{
    public class ResourceAsset : ScriptableObject
    {
        [ShowInInspector, ReadOnly]
        protected static string resourceFolderPath;

        protected static ResourceLoader<ResourceAsset> resourceLoader;

        [SerializeField] List<ResourceData> resourceDataList = new();

        public static List<T> GetResourceDataList<T>() where T : ResourceData
        {
            return resourceLoader.Resource.resourceDataList.Cast<T>().ToList();
        }
    }

    [System.Serializable]
    [InlineEditor]
    public class ResourceData : ScriptableObject
    {

    }

}