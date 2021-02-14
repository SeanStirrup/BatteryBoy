using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip PlayerDeathSound;
    public AudioSource AudioSource;
    public static bool PlayerDeathBool = false;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = PlayerDeathSound;
    }


    void Update()
    {
        if (PlayerDeathBool == true)
        {
            GetComponent<AudioSource>().Play();
            PlayerDeathBool = false;
        }
    }
}
