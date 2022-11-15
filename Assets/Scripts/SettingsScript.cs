using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public Dropdown dropdownMenuResolution;
    public Dropdown dropdownMenuQuality;
    public Toggle isFullscreen;
    public Slider volumeMusicSlider;
    public AudioMixer soundMixer;

    // go back to the main menu
    public void ToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    //set the new resolution
    public void ValidSettings()
    {
        // get the resolution
        int menuIndex = dropdownMenuResolution.GetComponent<Dropdown>().value;
        //get all options available within this dropdown menu
        List<Dropdown.OptionData> menuOptions = dropdownMenuResolution.GetComponent<Dropdown>().options;
        //get the string value of the selected index
        string[] resolution = menuOptions[menuIndex].text.Split('x', '2');
        Debug.Log(resolution);

        setVolume(volumeMusicSlider.value);
        QualitySettings.SetQualityLevel(this.getQualityFromDropDown(), true);
        Screen.SetResolution(1920, 1080, true);
    }

    private int getQualityFromDropDown()
    {
        /* there is only 3 value. 
         * 0*3 = 0 => low
         * 1*3 = 3 => medium
         * 2*3 = 6 => very high graphics
        */
        return dropdownMenuQuality.GetComponent<Dropdown>().value * 3;
    }

    public void setVolume(float volume)
    {
        soundMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}