using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class ButtonManager_HowFast : MonoBehaviour
{
    public int clicks;
    public Text showClicks;
    public static bool finished;
    public GameObject button;
    public static double finalClicks;

    public Text time;
    public float currTime;
    public float shownTime;

    public int inspector_laps;
    public static int laps;

    public static float velocity;

    private void Start()
    {
        currTime = 0;
        laps = inspector_laps;
        finished = false;
    }


    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("A_Button") || Input.GetKeyDown(KeyCode.Space)) && GameManager.gameStarted && !finished)
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

        if (!finished)
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

        if (finished)
        {
            finalClicks = clicks / ((int)((currTime) * 100f) / 100f);
            showClicks.text = finalClicks.ToString("F", CultureInfo.InvariantCulture) + " clicks per second.";
            velocity = 0;
            Destroy(button);
        }
    }

    void DisplayTime()
    {
        shownTime = (int)((currTime) * 100f) / 100f;
        if (!finished)
        {
            currTime += Time.deltaTime;
        }
    }

    public void IncrementCount()
    {
        clicks++;
    }

    public void Reset()
    {
        if (GameManager.privateMultiplayer)
        {
            Debug.Log("LEAVE");
            MultiplayerManager.LeaveRoom();
        }
        else
        {
            Debug.Log("LEAVE 2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}