using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource honk;
    public AudioSource crash;
    public AudioSource carLock;
    public AudioSource skid;
    public static AudioSource crashStatic;

    private void Start()
    {
        crashStatic = crash;
    }

    public void PlayHonk()
    {
        honk.Play();
    }

    public static void PlayCrash()
    {
        crashStatic.Play();
    }

    public void PlayCarLock()
    {
        carLock.Play();
    }

    public void PlaySkid()
    {
        skid.Play();
    }
}
