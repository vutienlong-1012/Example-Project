using UnityEngine;
using System;


namespace ExampleProject.Tools
{
    public sealed class VTLPlayerPrefs
    {
        public static void SetObjectValue<T>(string _key, T _value) where T : class
        {
            string _value2 = (_value != null) ? JsonUtility.ToJson(_value) : string.Empty;
            PlayerPrefs. SetString(_key, _value2);
        }
        public static T GetObjectValue<T>(string _key) where T : class
        {
            string @string = PlayerPrefs.GetString(_key,"");
            return (!string.IsNullOrEmpty(@string)) ? JsonUtility.FromJson<T>(@string) : ((T)((object)null));
        }
    }
}