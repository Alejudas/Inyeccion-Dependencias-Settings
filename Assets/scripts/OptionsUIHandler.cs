using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OptionsUIHandler : MonoBehaviour
{

    //Injections
    [Inject] AudioManager audioMa;
    [Inject] DisplaySettingsmanager displaySettings;

    [Header("--------Sounds Sliders--------")]
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [Space(10)]
    [Header("--------Screen Options--------")]
    [SerializeField] Toggle fullScreenToogle;

    [Space(10)]
    [Header("--------Screen resolution--------")]

    [SerializeField] TMP_Dropdown resolutionDropdown;


    [Space(10)]
    [Header("--------Graphics Quality--------")]

    [SerializeField] TMP_Dropdown qualityDropdown;

    private void Start()
    {
        LoadSliders();

        LoadFullScreenToggle();

        LoadResolutionDropDown();

        LoadQualityDropDown();
    }

    public void LoadQualityDropDown()
    {
        //QualitySettings.names.ToList();

        qualityDropdown.AddOptions(displaySettings.GetQualityNames());

        qualityDropdown.value = displaySettings.GetQualityLevel();

        qualityDropdown.onValueChanged.AddListener(delegate
        {
            displaySettings.SetQualityLevel(qualityDropdown.value);
        });

        //QualitySettings.SetQualityLevel();
    }

    public void LoadResolutionDropDown()
    {
        List<string> options = new();

        for (int i = 0; i < displaySettings.GetResolutions().Length; i++)
        {

            Resolution resolution = displaySettings.GetResolutions()[i];
            string format = resolution.width + " X " + resolution.height + resolution.refreshRateRatio.value.ToString("F0") + " Hz";
            options.Add(format);
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.onValueChanged.AddListener(delegate
        {
            displaySettings.SetResolution(resolutionDropdown.value);
        });

    }

    public void LoadFullScreenToggle()
    {
        fullScreenToogle.isOn = displaySettings.FullScreen();

        fullScreenToogle.onValueChanged.AddListener(delegate
        {
            displaySettings.SetFullScreen(fullScreenToogle.isOn);
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
