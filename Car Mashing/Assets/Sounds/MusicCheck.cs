using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCheck : MonoBehaviour
{
    public GameObject audioManager;

    private void Start()
    {
        if (FindObjectOfType<BackgroundMusic>())
        {
            return;
        }

        else
        {
            Instantiate(audioManager, transform.position, transform.rotation);
        }
    }
}
