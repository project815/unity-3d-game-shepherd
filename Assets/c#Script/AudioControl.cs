using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    //[SerializeField] Slider expSlider;

    const string MIXER_BGM = "BGM";
    const string MIXER_SFX = "SFX";
    //const string MIXER_EXP = "EXP";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        //expSlider.onValueChanged.AddListener(SetExpVolum);

    }
    //void SetExpVolum(float value)
    //{
    //    mixer.SetFloat(MIXER_EXP, Mathf.Log10(value) * 20);
    //}

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_BGM, Mathf.Log10(value) * 20);

    }
    void SetSfxVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);

    }
    //public static AudioControl instance;

    //private void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(instance);
    //    }
    //    else
    //    {
    //        Destroy(gameObject, 2);
    //    }
    //}
    //public void SFXPlay(string sfxName)
    //{
    //    GameObject go = new GameObject(sfxName + "Sound");
    //    AudioSource audiosource = go.AddComponent<AudioSource>();
    //    audiosource.clip = clip;
    //    audiosource.Play();

    //    Destory(gameObject, 2);
    //}
    //AudioMixer mixer;

    //public void SoundEffect()
    //{

    //}

    //[SerializeField] AudioMixer audioMixer;
    //[SerializeField] Slider volume;
    //[SerializeField] string ParameterName = "";

    //public void OnValueChanged(Slider volume)
    //{
    //    audioMixer.SetFloat(ParameterName,
    //       Mathf.Log10(volume.value) * 20);
    //}

    //public AudioMixer masterMixer;
    //public Slider audioSilder;

    //public void AudioManagement()
    //{
    //    float sound = audioSilder.value;

    //    if (sound == -40f) masterMixer.SetFloat("BGN", -80);
    //    else masterMixer.SetFloat("BGM", sound);

    //    if (sound == -40f) masterMixer.SetFloat("SFX", -80);
    //    else masterMixer.SetFloat("SFX", sound);
    //}
    //public void ToggleAudioVolume()
    //{
    //    //AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;   
    //}
}
