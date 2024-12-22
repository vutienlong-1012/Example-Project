using ExampleProject.UI.BaseUI.BasePopup;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleProject.Gameplay.Language
{
    [CreateAssetMenu(fileName = "LanguageData", menuName = "ScriptableObjects/LanguageData"), InlineEditor]
    public class LanguageData : ScriptableObject
    {
        #region Fields

        [PreviewField] public Sprite flag;
        public LanguageId id;
        public string code;

        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }

    public enum LanguageId
    {
        None = 0,
        Chinese = 1,
        English = 2,
        France = 3,
        German = 4,
        Indonesia = 5,
        Italy = 6,
        Japanese = 7,
        Korean = 8,
        Portuguese = 9,
        Russian = 10,
        Spanish = 11,
        Vietnam = 12,
    }
}
