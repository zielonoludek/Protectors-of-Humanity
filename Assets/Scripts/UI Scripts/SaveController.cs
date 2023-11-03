using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class SaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] public Toggle toggleBtn;

    [SerializeField] private TextMeshProUGUI volumeText = null;

    private const string musicMuteKey = "musicMuted";

    private void Start()
    {
        bool isMusicMuted = PlayerPrefs.GetInt(musicMuteKey, 0) == 1;
        toggleBtn.isOn = isMusicMuted;
        musicState(isMusicMuted);
        LoadValues();
    }


    public void VolumeController(float volume)
    {
        float volumeProcentage = volume * 100f;
        
        volumeText.text = volumeProcentage.ToString("0");
    }

    public void VolumeSaveButton()
    {
        float volumeProcentage = volumeSlider.value * 100f;
        AudioListener.volume = volumeProcentage;
        PlayerPrefs.SetFloat("volumeValue", volumeProcentage);
        LoadValues();
    }

    public void musicMute()
    {
        bool isMusicMuted = toggleBtn.isOn;
        musicState(isMusicMuted);
        PlayerPrefs.SetInt(musicMuteKey, isMusicMuted ? 1 : 0);
    }

    private void musicState(bool musicMuted)
    {
        if (musicMuted)
        {
            //mute our music
        }
        else
        {
            //unmute our music
        }
    }

    void LoadValues()
    {
        float volumeProcentage = PlayerPrefs.GetFloat("volumeValue");
        float volumeValue = volumeProcentage / 100f;
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
