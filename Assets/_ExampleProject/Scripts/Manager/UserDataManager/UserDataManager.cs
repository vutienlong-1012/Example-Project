using ExampleProject.Tools;
using I2.Loc;
using Sirenix.OdinInspector;
using System;
using System.Globalization;
using UnityEngine;

namespace ExampleProject.Manager
{
    public class UserDataManager
    {
        public static float SoundVolume
        {
            get => float.Parse(UserData.soundVolume, CultureInfo.InvariantCulture);
            set
            {
                UserData.soundVolume = value.ToString(CultureInfo.InvariantCulture);
                SaveData();
            }
        }
        public static float MusicVolume
        {
            get => float.Parse(UserData.musicVolume, CultureInfo.InvariantCulture);
            set
            {
                UserData.musicVolume = value.ToString(CultureInfo.InvariantCulture);
                SaveData();
            }
        }
        public static bool IsVibrationOn
        {
            get => UserData.isVibrationOn;
            set
            {
                UserData.isVibrationOn = value;
                SaveData();
            }
        }
        public static string CurrentLanguage
        {
            get => UserData.currentLanguage;
            set
            {
                UserData.currentLanguage = value;
                LocalizationManager.CurrentLanguage = value;
                SaveData();
            }
        }
        public static bool IsCheatNoAd
        {
            get => UserData.isCheatNoAds;
            set
            {
                UserData.isCheatNoAds = value;
                SaveData();
            }
        }
        public static bool IsShowFps
        {
            get => UserData.isShowFps;
            set
            {
                UserData.isShowFps = value;
                SaveData();
            }
        }
        public static bool IsShowDebug
        {
            get => UserData.isShowDebug;
            set
            {
                UserData.isShowDebug = value;
                SaveData();
            }
        }
        public static int CountGamePlayed
        {
            get => UserData.countGamePlayed;
            set
            {
                UserData.countGamePlayed = value;
                SaveData();
            }
        }
        public static DateTime FistTimePlay
        {
            get => DateTime.Parse(UserData.fistTimePlay, CultureInfo.InvariantCulture);
            set
            {
                UserData.fistTimePlay = value.ToString(CultureInfo.InvariantCulture);
                SaveData();
            }
        }

        #region User Data

        public static UserData UserData { get; private set; }
        public static void SetUserData(UserData _data)
        {
            UserData = _data;
            SaveData();
        }
        static UserDataManager()
        {
            UserData = GetData();
            if (UserData == null)
            {
                UserData = new();
                SaveData();
            }
        }
        static void SaveData()
        {
            VTLPlayerPrefs.SetObjectValue(StringsSafeAccess.PREF_USER_DATA, UserData);
        }
        static UserData GetData()
        {
            return VTLPlayerPrefs.GetObjectValue<UserData>(StringsSafeAccess.PREF_USER_DATA);
        }

        #endregion
    }

    [Serializable]
    public class UserData
    {

        [BoxGroup("System")] public string soundVolume;
        [BoxGroup("System")] public string musicVolume;
        [BoxGroup("System")] public bool isVibrationOn;
        [BoxGroup("System")] public string currentLanguage;

        [BoxGroup("Develop")] public bool isCheatNoAds;
        [BoxGroup("Develop")] public bool isShowFps;
        [BoxGroup("Develop")] public bool isShowDebug;

        [BoxGroup("Data")] public int countGamePlayed;
        [BoxGroup("Data")] public string fistTimePlay;

        public UserData()
        {
            soundVolume = "1";
            musicVolume = "1";
            isVibrationOn = true;
            currentLanguage = LocalizationManager.CurrentLanguage;

            countGamePlayed = 0;

            isCheatNoAds = false;
            isShowFps = false;
            isShowDebug = false;

            fistTimePlay = DateTime.MinValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}