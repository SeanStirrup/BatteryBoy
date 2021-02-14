using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSoundScript : MonoBehaviour
{
    public AudioClip DeathSound;
    public AudioSource AudioSource;
    public static bool DeathBool = false;
    
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = DeathSound;
    }

    
    void Update()
    {
        if (DeathBool == true)
        {
            GetComponent<AudioSource>().Play();
            DeathBool = false;
        }
    }
}
