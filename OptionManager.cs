using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public int settingTime;
    static int time = 5;
    public int settingLaps;
    static int laps = 1;
    static int timeTrialTime = 10;

    public Text currentSettings;

    void Update()
    {
        currentSettings.text = "Free Play: " + time + " seconds, \nTime Trials: " + laps + " lap(s)";
    }

    public void SetTime()
    {
        time = settingTime;
    }

    public void SetTimeTT()
    {
        timeTrialTime = settingTime;
    }

    public static int GetSeconds()
    {
        return time;
    }

    public static int GetSecondsTT()
    {
        return timeTrialTime;
    }

    public void SetLaps()
    {
        laps = settingLaps;
    }

    public static int GetLaps()
    {
        return laps;
    }

    public void BackToModes()
    {
        SceneManager.LoadScene("Modes");
    }
}
