using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OptionsUIHandler : MonoBehaviour
{
    [Inject] AudioManager audioMa;


    [Header("--------Sounds Sliders--------")]
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [Header("--------Screen Options--------")]
    [SerializeField] Toggle fullScreen;

    [Header("--------Screen resolution--------")]

    [SerializeField] TMP_Dropdown resolutionDropdown;


    private void Start()
    {
        LoadSliders();

        LoadFullScreenToggle();

        LoadResolutionDropDown();

    }

    public void LoadResolutionDropDown()
    {
        List<string> options = new();

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            
            Resolution resolution = Screen.resolutions[i];
            string format = resolution.width + "X" + resolution.height + resolution.refreshRateRatio.value.ToString("F0") + "Hz";
            options.Add(format);
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.onValueChanged.AddListener(delegate
        {

        });

    }

    public void LoadFullScreenToggle()
    {
        fullScreen.onValueChanged.AddListener(delegate
        {
            Screen.fullScreen = fullScreen.isOn;
        });
    }

    public void LoadSliders()
    {

        masterSlider.value = audioMa.MasterV;

        masterSlider.onValueChanged.AddListener(delegate
        {
            audioMa.SetMasterVolume(masterSlider.value);
        });


        musicSlider.value = audioMa.MusicV;

        musicSlider.onValueChanged.AddListener(delegate
        {
            audioMa.SetMusicVolume(musicSlider.value);
        });

        sfxSlider.value = audioMa.SfxV;

        sfxSlider.onValueChanged.AddListener(delegate
        {
            audioMa.SetSFXVolume(sfxSlider.value);
        });
    }
}
