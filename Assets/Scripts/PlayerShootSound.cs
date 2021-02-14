using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootSound : MonoBehaviour
{
    public AudioClip PlayerShotSound;
    public AudioSource AudioSource;
    public static bool PlayerShootBool = false;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = PlayerShotSound;
    }


    void Update()
    {
        if (PlayerShootBool == true)
        {
            GetComponent<AudioSource>().Play();
            PlayerShootBool = false;
        }
    }
}
