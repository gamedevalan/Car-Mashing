using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class ButtonManager_FreePlay : MonoBehaviour
{
    public int clicks;
    public Text showClicks;
    private readonly float seconds = OptionManager.GetSeconds();
    public static bool done;
    public GameObject button;

    public Text time;
    public float currTime;
    public float shownTime;

    public static float velocity;
    private double finalClicks;

    private void Start()
    {
        done = false;
        currTime = 0;
        shownTime = seconds;
    }

    // Start is called before the first frame update
    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(button);
        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("A_Button") || Input.GetKeyDown(KeyCode.Space)) && !done)
        {
            IncrementCount();
        }

        if (Input.GetButtonDown("Start_Button"))
        {
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

        if (done)
        {
            finalClicks = clicks / ((int)((currTime) * 100f) / 100f);
            showClicks.text = finalClicks.ToString("F", CultureInfo.InvariantCulture) + " clicks per second.";            
            velocity = 0;
        }

        if (done)
        {
            Destroy(button);
        }
    }

    void DisplayTime()
    {
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
