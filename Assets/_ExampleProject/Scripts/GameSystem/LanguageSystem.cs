using I2.Loc;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using ExampleProject.Tools;

namespace ExampleProject.GameSystem
{
    public class LanguageSystem : Singleton<LanguageSystem>
    {
        #region Fields



        #endregion

        #region Properties

        [ShowInInspector, ReadOnly]
        public List<string> AllLanguages
        {
            get => LocalizationManager.GetAllLanguages();
        }

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Protected Methods



        #endregion

        #region Public Methods

        public void ChangeLanguage(int _newLangIndex)
        {
            UserDataManager.CurrentLanguage = AllLanguages[_newLangIndex];
        }

        #endregion
    }
}