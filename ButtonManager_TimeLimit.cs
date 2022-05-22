using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class ButtonManager_TimeLimit : MonoBehaviour
{
    public int clicks;
    public Text showClicks;
    private float seconds = OptionManager.GetSecondsTT();
    public static bool done;
    public static bool finished;
    public GameObject button;

    public Text time;
    public float currTime;
    public float shownTime;

    //public int inspector_laps;
    // able to use in other classes.
    public static int laps;
    public Text showLaps;

    public static float velocity;
    private double finalClicks;
    private bool played = false;

    private void Start()
    {
        currTime = 0;
        shownTime = seconds;
        laps = OptionManager.GetLaps();
        showLaps.text = laps + " total lap(s)";
        finished = false;
        done = false;
    }

    // Start is called before the first frame update
    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(seconds);
        if (!finished)
        {
            Destroy(button);
        }
        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("A_Button") || Input.GetKeyDown(KeyCode.Space)) && (!done && !finished))
        {
            IncrementCount();
        }
        if (Input.GetButtonDown("Start_Button")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        time.text = shownTime + " seconds";
        if (clicks > 0)
        {
            DisplayTime();
        }

        if (!done)
        {
            showClicks.text = clicks + " times clicked.";
            if (currTime == 0)
            {
                velocity = 0;
            }
            else
            {
                velocity = (clicks / currTime) * .4f;
            }
        }

        if(finished || done)
        {
            if (seconds == currTime)
            {
                showClicks.text = "Track Failed";
                if (!SoundEffects.crashStatic.isPlaying && !played)
                {
                    SoundEffects.PlayCrash();
                    played = true;
                }
            }
            else
            {
                finalClicks = clicks / ((int)((currTime) * 100f) / 100f);
                showClicks.text = finalClicks.ToString("F", CultureInfo.InvariantCulture) + " clicks per second.";
            }
            velocity = 0;
        }

        if (finished)
        {
            Destroy(button);
        }
    }

    void DisplayTime()
    {
        if (!finished) {
            shownTime = (int)((seconds - currTime) * 100f) / 100f;
            if (currTime < seconds)
            {
                currTime += Time.deltaTime;
            }
            else
            {
                currTime = seconds;
            }
        }
    }

    public void IncrementCount()
    {
        if (clicks == 0)
        {
            StartTimer();
        }
        clicks++;
    }

    public void Reset()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Modes");
    }
}
