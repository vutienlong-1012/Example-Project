using I2.Loc;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

namespace ExampleProject
{
    public class LanguageSystem : Singleton<LanguageSystem>
    {
        [ShowInInspector, ReadOnly]
        public List<string> AllLanguages
        {
            get => LocalizationManager.GetAllLanguages();
        }

        public void ChangeLanguage(int _newLangIndex)
        {
            UserDataManager.CurrentLanguage = AllLanguages[_newLangIndex];
        }
    }
}