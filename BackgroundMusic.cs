using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource BGM;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<BackgroundMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMusic(AudioClip music)
    {
        if (BGM.clip.name == music.name)
        {
            return;
        }

        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
