using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.UI.ContentSizeFitter;

public class AudioSlider : GameBehaviour
{
    public AudioMixer audioMixer;
    public AudioType audioType;

    public GameObject bgmSource;
    public GameObject playerSource;
    public GameObject effectsSource;
    public AudioSource soundSource;
    public AudioMixerGroup bgmMix;
    public AudioMixerGroup playerMix;
    public AudioMixerGroup effectsMix;



    public enum AudioType { Master, BGM, Player, Effects }

    void Start()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }

    public void OnChangeSlider(float Value)
    {

        switch (audioType)
        {
            //case audioType.LinearAudioSourceVolume:
            //    AudioSource.volume = Value;
            //    break;
            //case AudioMixMode.LinearMixerVolume:
            //    Mixer.SetFloat("Volume", (-80 + Value * 80));
            //    break;

            //case AudioType.BGM:
            //    audioMixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
            //    break;

            case AudioType.BGM:
                soundSource = bgmSource.GetComponent<AudioSource>();
                bgmMix.audioMixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;

            case AudioType.Player:
                soundSource = playerSource.GetComponent<AudioSource>();
                playerMix.audioMixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;

            case AudioType.Effects:
                soundSource = effectsSource.GetComponent<AudioSource>();
                effectsMix.audioMixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                //udioMixer[audio]a
                break;

        }

        // Update is called once per frame
        //void Update()
        //{

        //}
    }
}
        