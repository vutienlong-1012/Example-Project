using System.Collections;
using System.Collections.Generic;
using ExampleProject.Tools;
using UnityEngine;


namespace ExampleProject.GameSystem
{
    public class MusicSystem : Singleton<MusicSystem>
    {
        [SerializeField] private AudioSource musicAudioSource;


        private void OnEnable()
        {
            musicAudioSource.mute = !UserDataManager.IsMusicOn;
        }

        public void PlayMusic(AudioClip _audioClip)
        {
            if (!UserDataManager.IsMusicOn)
            {
                musicAudioSource.clip = _audioClip;
                return;
            }
            else
            {
                musicAudioSource.clip = _audioClip;
                musicAudioSource.Play();
            }
        }

        public void SetMusic(bool _value)
        {
            UserDataManager.IsMusicOn = _value;
            musicAudioSource.mute = !UserDataManager.IsMusicOn;
        }
    }
}