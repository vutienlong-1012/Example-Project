using System.Collections;
using System.Collections.Generic;
using ExampleProject.Manager;
using ExampleProject.Tools;
using UnityEngine;


namespace ExampleProject.GameSystem
{
    public class SoundSystem : Singleton<SoundSystem>
    {
        #region Fields

        [SerializeField] AudioSource shareAudioSource;
        [SerializeField] AudioSource uIAudioSource;
        [SerializeField] AudioClip uIOnClickAudioClip;

        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Protected Methods



        #endregion

        #region Public Methods

        public void PlaySoundOneShot(AudioSource _audioSource, AudioClip _audioClip)
        {
            if (!UserDataManager.IsSoundOn)
                return;
            else
                _audioSource.PlayOneShot(_audioClip);
        }
        public void PlaySoundOneShot(AudioSource _audioSource, AudioClip _audioClip, float _volume)
        {
            if (!UserDataManager.IsSoundOn)
                return;
            else
                _audioSource.PlayOneShot(_audioClip, _volume);
        }
        public void PlayUIClick()
        {
            if (!UserDataManager.IsSoundOn)
                return;
            else
                uIAudioSource.PlayOneShot(uIOnClickAudioClip);
        }
        public void SetSound(bool _value)
        {
            UserDataManager.IsSoundOn = _value;
        }

        #endregion
    }
}