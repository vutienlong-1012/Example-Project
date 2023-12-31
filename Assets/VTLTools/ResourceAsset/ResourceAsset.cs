using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VTLTools.ResoureAsset
{
    public class ResourceAsset : ScriptableObject
    {
        protected static string ITEM_RESOURCE_FOLDER_PATH;

        protected static ResourceLoader<ResourceAsset> asset = new(ITEM_RESOURCE_FOLDER_PATH);


        [SerializeField] protected List<ResourceData> dataList = new();

        public static List<ResourceData> GetDataList()
        {
            return asset.Value.dataList;
        }
    }

    [System.Serializable]
    [InlineEditor]
    public class ResourceData:ScriptableObject
    {

    }

}