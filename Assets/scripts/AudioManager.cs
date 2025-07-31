using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    string masterKey = "MasterVolume";
    string sfxKey = "SFXVolume";
    string musicKey = "MusicVolume";


    public float MusicV { get => _musicV;}
    float _masterV;
    public float SfxV { get => _sfxV; }
    float _sfxV;
    public float MasterV { get => _masterV; }
    float _musicV;

    private void Start()
    {

        SetMasterVolume(PlayerPrefs.HasKey(masterKey) ? PlayerPrefs.GetFloat(masterKey) : 1);
        SetMusicVolume(PlayerPrefs.HasKey(musicKey) ? PlayerPrefs.GetFloat(musicKey) : 1);
        SetSFXVolume(PlayerPrefs.HasKey(sfxKey) ? PlayerPrefs.GetFloat(sfxKey) : 1);
        
    }


    public void SetMasterVolume(float volume)
    {
        _masterV = volume;
        PlayerPrefs.SetFloat(masterKey, volume);
        mixer.SetFloat(masterKey, ToDecibel(volume));
    }
    public void SetSFXVolume(float volume)
    {
        _sfxV = volume;
        PlayerPrefs.SetFloat(sfxKey, volume);
        mixer.SetFloat(sfxKey, ToDecibel(volume));
    }
    public void SetMusicVolume(float volume)
    { 
        _musicV = volume;
        PlayerPrefs.SetFloat(musicKey, volume);
        mixer.SetFloat(musicKey, ToDecibel(volume));
    }

    public float ToDecibel(float volume)
    {
        return Mathf.Log10(volume) * 20;
    }
}

