using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject linkScreen;

    private void Start()
    {
        linkScreen.SetActive(false);
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene("Modes");
    }

    public void Credits()
    {
        linkScreen.SetActive(true);
    }

    public void Back()
    {
        linkScreen.SetActive(false);
    }

}
