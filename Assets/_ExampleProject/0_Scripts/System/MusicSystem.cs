using System.Collections;
using System.Collections.Generic;
using VTLTools;
using UnityEngine;


namespace ExampleProject
{
    public class MusicSystem : Singleton<MusicSystem>
    {
        [SerializeField] private AudioSource musicAudioSource;


        private void OnEnable()
        {
            musicAudioSource.mute = !StaticVariables.IsMusicOn;
        }

        public void PlayMusic(AudioClip _audioClip)
        {
            if (!StaticVariables.IsMusicOn)
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

        public void ToggeMusic()
        {
            StaticVariables.IsMusicOn = !StaticVariables.IsMusicOn;
            musicAudioSource.mute = !StaticVariables.IsMusicOn;
        }
    }
}