using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExampleProject.Tools;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

namespace ExampleProject.Gameplay.Language
{
    [CreateAssetMenu(fileName = "Languages", menuName = "ScriptableObjects/Languages")]
    public class Languages : ScriptableObject
    {
        #region Fields

        [SerializeField] List<LanguageData> resourceDataList = new();
        const string resourceFolderPath = "Data/Popups";
        static ResourceLoader<Languages> resourceLoader = new(resourceFolderPath);

        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static List<LanguageData> GetResourceDataList()
        {
            return resourceLoader.Resource.resourceDataList;
        }
        public static LanguageData GetResourceData(LanguageId _id)
        {
            var _data = GetResourceDataList().Find(x => x.id.Equals(_id));
            return _data;
        }

        #endregion      
    }
}