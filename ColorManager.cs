using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ColorManager : MonoBehaviour
{
    private static Color carColor = new Color(1f,1f,1f,1f);
    private static string mode;
    public static Sprite curBackground = null;
    public Sprite defaultBG;

    public Sprite grass;
    public Sprite beach;
    public Sprite snow;

    public Text colorAndTrack;
    private string colorName = "Gray";
    private string trackName = "Grass";

    void Start()
    {
        curBackground = defaultBG;
    }

    void Update()
    {
        colorAndTrack.text = colorName + " Car, " + trackName + " Track";
    }

    public void ColorGrey()
    {
        carColor = new Color(1f, 1f, 1f, 1f);
        colorName = "Grey";
    }

    public void ColorBlue()
    {
        carColor = new Color(0f, 0f, 1f, 1f);
        colorName = "Blue";
    }

    public void ColorRed()
    {
        carColor = new Color(1f, 0f, 0f, 1f);
        colorName = "Red";
    }

    public void ColorGreen()
    {
        carColor = new Color(0f, 1f, 0f, 1f);
        colorName = "Green";
    }

    public void ColorYellow()
    {
        carColor = new Color(1f, 0.92f, 0.016f, 1f);
        colorName = "Yellow";
    }

    public static Color GetCarColor()
    {
        return carColor;
    }

    public void SetDefaultBackground()
    {
        curBackground = grass;
        trackName = "Grass";
    }

    public void SetBeachBackground()
    {
        curBackground = beach;
        trackName = "Beach";
    }

    public void SetSnowBackground()
    {
        curBackground = snow;
        trackName = "Snow";
    }

    public static Sprite GetBackground()
    {
        return curBackground;
    }

    public void GoToMode()
    {
        SceneManager.LoadScene(mode);
    }

    public void GoToChooseMode()
    {
        SceneManager.LoadScene("Modes");
    }

    public void SinglePlayerFreePlay()
    {
        mode = "FreePlay";
        SceneManager.LoadScene("ChooseColor");
    }

    public void SinglePlayerTimeTrials()
    {
        mode = "Time Limit";
        SceneManager.LoadScene("ChooseColor");
    }

    public void Multiplayer()
    {
        mode = "RoomMaker";
        SceneManager.LoadScene("ChooseColor");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Back()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
