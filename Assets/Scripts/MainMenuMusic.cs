using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("Music") == -1)
        {
            audioSource.Stop();
        }
    }
}
