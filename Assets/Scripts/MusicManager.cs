using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [SerializeField]private AudioClip buttonClip;
    [SerializeField] private AudioClip takeGoldClip;
    [SerializeField] private AudioClip enemySpawnClip;
    [SerializeField] private AudioClip endMusicClip;
    private AudioSource audioSource;
    void Start()
    {
        Instance = GetComponent<MusicManager>();
        DontDestroyOnLoad(gameObject);
        audioSource =GetComponent<AudioSource>();
    }
    public void PlayButtonClip()
    {
        audioSource.clip = buttonClip;
        PlaySound();
    }
    
    public void PlayTakeGoldClip()
    {
        audioSource.clip = takeGoldClip;
        PlaySound();
    }
    public void PlayEnemySpawnClip()
    {
        audioSource.clip = enemySpawnClip;
        PlaySound();
    }
    public void PlayEndMusicClip()
    {
        audioSource.clip = endMusicClip;
        PlaySound();
    }
    private void PlaySound()
    {
        audioSource.Play();
    }
}
