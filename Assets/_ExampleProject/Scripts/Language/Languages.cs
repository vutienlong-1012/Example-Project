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
        const string resourceFolderPath = "Data/Languages";
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
        public static LanguageData GetResourceData(string _id)
        {
            var _data = GetResourceDataList().Find(x => x.code.Equals(_id));
            return _data;
        }

        #endregion      
    }
}