using ExampleProject.Tools;
using I2.Loc;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace ExampleProject.Manager
{
    public class UserDataManager 
    {
        public static bool IsSoundOn
        {
            get => UserData.isSoundOn;
            set
            {
                UserData.isSoundOn = value;
                SaveData();
            }
        }
        public static bool IsMusicOn
        {
            get => UserData.isMusicOn;
            set
            {
                UserData.isMusicOn = value;
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
        public static int CountGamePlayed
        {
            get => UserData.countGamePlayed;
            set
            {
                UserData.countGamePlayed = value;
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
        public static bool IsShowMaxMediationDebug
        {
            get => UserData.isShowMediationDebug;
            set
            {
                UserData.isShowMediationDebug = value;
                SaveData();
            }
        }
        public static bool IsRated
        {
            get => UserData.isRated;
            set
            {
                UserData.isRated = value;
                SaveData();
            }
        }
        public static bool IsShowRateAtLeastOne
        {
            get => UserData.isShowRateAtLeastOne;
            set
            {
                UserData.isShowRateAtLeastOne = value;
                SaveData();
            }
        }
        public static int CurrentIndexShowRate
        {
            get => UserData.currentIndexShowRate;
            set
            {
                UserData.currentIndexShowRate = value;
                SaveData();
            }
        }
        public static bool IsRemovedAds
        {
            get => UserData.isRemovedAds;
            set
            {
                UserData.isRemovedAds = value;
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

        public bool isSoundOn;
        public bool isMusicOn;
        public bool isVibrationOn;
        public string currentLanguage;

        public int countGamePlayed;

        public bool isCheatNoAds;
        public bool isShowFps;
        public bool isShowDebug;
        public bool isShowMediationDebug;

        public bool isRated;
        public bool isShowRateAtLeastOne;
        public int currentIndexShowRate;

        public bool isRemovedAds;

        public UserData()
        {
            isSoundOn = true;
            isMusicOn = true;
            isVibrationOn = true;
            currentLanguage = LocalizationManager.CurrentLanguage;

            countGamePlayed = 0;

            isCheatNoAds = false;
            isShowFps = false;
            isShowDebug = false;
            isShowMediationDebug = false;

            isRated = false;
            isShowRateAtLeastOne = false;
            currentIndexShowRate = 0;

            isRemovedAds = false;
        }
    }
}