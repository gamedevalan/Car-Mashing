using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModePreviews : MonoBehaviour
{
    public GameObject timeTrialPreview;
    public GameObject freePlayPreview;
    public GameObject multiplayerPreview;
    public GameObject grass;

    public void ShowFreePlay()
    {
        freePlayPreview.SetActive(true);
        grass.SetActive(true);
    }

    public void HideFreePlay()
    {
        if (freePlayPreview != null && grass != null)
        {
            freePlayPreview.SetActive(false);
            grass.SetActive(false);
        }
    }

    public void ShowTimeTrial()
    {
        timeTrialPreview.SetActive(true);
        grass.SetActive(true);
    }

    public void HideTimeTrial()
    {
        if (timeTrialPreview != null && grass != null)
        {
            timeTrialPreview.SetActive(false);
            grass.SetActive(false);
        }
    }

    public void ShowMultiplayer()
    {
        multiplayerPreview.SetActive(true);
        grass.SetActive(true);
    }

    public void HideMultiplayer()
    {
        if (multiplayerPreview != null && grass != null)
        {
            multiplayerPreview.SetActive(false);
            grass.SetActive(false);
        }
    }
}
