using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Dropdown dropdownMenuResolution;
    public Dropdown dropdownMenuQuality;
    public Toggle isFullscreen;

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
        string[] resolution = menuOptions[menuIndex].text.Split("x",2);


        QualitySettings.SetQualityLevel(this.getQualityFromDropDown(), true);
        Screen.SetResolution(int.Parse(resolution.GetValue(0).ToString()), int.Parse(resolution.GetValue(1).ToString()), isFullscreen.isOn);
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
}