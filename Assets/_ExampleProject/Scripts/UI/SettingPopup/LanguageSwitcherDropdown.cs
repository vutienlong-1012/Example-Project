using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;
using ExampleProject.Tools;
using ExampleProject.UI.BaseUI;
using ExampleProject.GameSystem;

namespace ExampleProject.UI.SettingPopup
{
    public class LanguageSwitcherDropdown : BaseDropdown
    {
        protected override void OnEnable()
        {
            Init();
            base.OnEnable();
        }

        void Init()
        {
            ThisDropdown.ClearOptions();
            var _languages = LanguageSystem.Instance.AllLanguages;
            for (int i = 0; i < _languages.Count; i++)
            {
                Dropdown.OptionData _optionData = new()
                {
                    text = LocalizationManager.GetTranslation(_languages[i], true, 0, true, false, null, _languages[i], true),
                };
                ThisDropdown.options.Add(_optionData);

                if (_languages[i] == UserDataManager.CurrentLanguage)
                {
                    ThisDropdown.value = i;
                    ThisDropdown.RefreshShownValue();
                }
            }
        }

        protected override void ListenerMethod(int _value)
        {
            LanguageSystem.Instance.ChangeLanguage(_value);
            base.ListenerMethod(_value);
        }
    }
}