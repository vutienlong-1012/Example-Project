using I2.Loc;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace VTLTools
{
    public class UserDataManager : MonoBehaviour
    {
        public static bool IsSoundOn
        {
            get => userData.isSoundOn;
            set
            {
                userData.isSoundOn = value;
                SaveData();
            }
        }

        public static bool IsMusicOn
        {
            get => userData.isMusicOn;
            set
            {
                userData.isMusicOn = value;
                SaveData();
            }
        }

        public static bool IsVibrationOn
        {
            get => userData.isVibrationOn;
            set
            {
                userData.isVibrationOn = value;
                SaveData();
            }
        }

        public static string CurrentLanguage
        {
            get => userData.currentLanguage;
            set
            {
                userData.currentLanguage = value;
                LocalizationManager.CurrentLanguage = value;
                SaveData();
            }
        }

        public static int CountGamePlayed
        {
            get => userData.countGamePlayed;
            set
            {
                userData.countGamePlayed = value;
                SaveData();
            }
        }

        public static bool IsCheatNoAd
        {
            get => userData.isCheatNoAds;
            set
            {
                userData.isCheatNoAds = value;
                SaveData();
            }
        }

        public static bool IsShowFps
        {
            get => userData.isShowFps;
            set
            {
                userData.isShowFps = value;
                SaveData();
            }
        }

        public static bool IsShowDebug
        {
            get => userData.isShowDebug;
            set
            {
                userData.isShowDebug = value;
                SaveData();
            }
        }

        public static bool IsShowMaxMediationDebug
        {
            get => userData.isShowMediationDebug;
            set
            {
                userData.isShowMediationDebug = value;
                SaveData();
            }
        }

        public static bool IsRated
        {
            get => userData.isRated;
            set
            {
                userData.isRated = value;
                SaveData();
            }
        }

        public static bool IsShowRateAtLeastOne
        {
            get => userData.isShowRateAtLeastOne;
            set
            {
                userData.isShowRateAtLeastOne = value;
                SaveData();
            }
        }

        public static int CurrentIndexShowRate
        {
            get => userData.currentIndexShowRate;
            set
            {
                userData.currentIndexShowRate = value;
                SaveData();
            }
        }

        public static bool IsRemovedAds
        {
            get => userData.isRemovedAds;
            set
            {
                userData.isRemovedAds = value;
                SaveData();
            }
        }

        #region User Data
        static UserData userData;

        static UserDataManager()
        {
            userData = GetData();
            if (userData == null)
            {
                userData = new UserData();
                SaveData();
            }
        }
        static void SaveData()
        {
            VTLPlayerPrefs.SetObjectValue(StringsSafeAccess.PREF_USER_DATA, userData);
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