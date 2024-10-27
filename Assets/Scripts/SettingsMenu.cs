using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown; // Dropdown to select resolution
    public Slider volumeSlider; // Slider to adjust volume
    public AudioMixer audioMixer; // AudioMixer to control global volume

    private Resolution[] resolutions; // Array to store available resolutions

    void Start()
    {
        // Populate resolution options in dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Check if this resolution is the current resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Set the initial volume slider value to the current volume
        float volume;
        audioMixer.GetFloat("Volume", out volume);
        volumeSlider.value = Mathf.Pow(10, volume / 20); // Convert dB to linear
    }

    public void SetResolution(int resolutionIndex)
    {
        // Set the screen resolution based on the selected dropdown index
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        // Convert linear volume (0-1) to decibels for AudioMixer
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}