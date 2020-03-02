using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropDown;
    public Dropdown graphicsDropDown;
    public Slider volumeSlider;
    public Toggle fullScreen;   
    private void Start()
    {
        resolutions = RemoveDuplicateResolutions(Screen.resolutions);
        resolutionDropDown.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;

            options.Add(resolutions[i].width + " x " + resolutions[i].height);
        }
            
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        graphicsDropDown.value = 2;
        QualitySettings.SetQualityLevel(2);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        fullScreen.isOn = Screen.fullScreen;
    }

    private Resolution[] RemoveDuplicateResolutions(Resolution[] resArr)
    {
        Resolution res = resArr[0];
        List<Resolution> lstRes = new List<Resolution>();

        for (int i = 0; i < resArr.Length; i++)
        {
            if (!((resArr[i].width == res.width) && (resArr[i].height == res.height)))
            {
                lstRes.Add(res);
                res = resArr[i];
            }
        }

        return lstRes.ToArray();
    }
    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("Volume",volume);
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetScreenMode(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height,Screen.fullScreen);
    }

    public void ExitButton()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene(0);
    }
}
