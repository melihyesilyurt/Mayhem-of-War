using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInterFace : MonoBehaviour
{
    public static GameInterFace Instance;
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject voiceOnButton;
    [SerializeField] private GameObject voiceOffButton;
    [SerializeField] private GameObject musicOnButton;
    [SerializeField] private GameObject musicOffButton;
    [SerializeField] private Canvas settingsMenu;
    [SerializeField] private Canvas gameOverMenu;
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button goMainMenuButton;
    public Text scoreText;
    public Text goldText;
    public Text scoreTextPanel;
    public Text HighScoreTextPanel;
    private AudioSource audioSource;
    void Start()
    {
        Instance = GetComponent<GameInterFace>();
        gameOverMenu.enabled = false;
        pauseMenu.enabled = false;
        settingsMenu.enabled = false;
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            audioSource.Play();
            musicOffButton.SetActive(false);
            musicOnButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Music") == -1)
        {
            audioSource.Stop();
            musicOffButton.SetActive(true);
            musicOnButton.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Voice") == 0)
        {
            voiceOffButton.SetActive(false);
            voiceOnButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Voice") == -1)
        {
            voiceOffButton.SetActive(true);
            voiceOnButton.SetActive(false);
        }
    }
    public void OpenPauseMenu()
    {
        MusicManager.Instance.PlayButtonClip();
        pauseMenu.enabled = true;
        Time.timeScale = 0;
    }
    public void ClosePauseMenu()
    {
        MusicManager.Instance.PlayButtonClip();
        pauseMenu.enabled = false;
        settingsMenu.enabled = false;
        Time.timeScale = 1;
    }
    public void OpenSettingsMenu()
    {
        MusicManager.Instance.PlayButtonClip();
        settingsMenu.enabled = true;
    }
    public void GoMainMenu()
    {
        MusicManager.Instance.PlayButtonClip();
        RouteManager.Instance.LoadMainMenu();
        Time.timeScale = 1;
    }
    public void VoiceOn()
    {
        MusicManager.Instance.PlayButtonClip();
        PlayerPrefs.SetInt("Voice", 0);
        voiceOffButton.SetActive(false);
        voiceOnButton.SetActive(true);

    }
    public void VoiceOff()
    {
        MusicManager.Instance.PlayButtonClip();
        PlayerPrefs.SetInt("Voice", -1);
        voiceOffButton.SetActive(true);
        voiceOnButton.SetActive(false);
    }
    public void MusicOn()
    {
        MusicManager.Instance.PlayButtonClip();
        PlayerPrefs.SetInt("Music", 0);
        musicOffButton.SetActive(false);
        musicOnButton.SetActive(true);
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            audioSource.Play();
            musicOffButton.SetActive(false);
            musicOnButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Music") == -1)
        {
            audioSource.Stop();
            musicOffButton.SetActive(true);
            musicOnButton.SetActive(false);
        }
    }
    public void MusicOff()
    {
        MusicManager.Instance.PlayButtonClip();
        PlayerPrefs.SetInt("Music", -1);
        musicOffButton.SetActive(true);
        musicOnButton.SetActive(false);
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            audioSource.Play();
            musicOffButton.SetActive(false);
            musicOnButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Music") == -1)
        {
            audioSource.Stop();
            musicOffButton.SetActive(true);
            musicOnButton.SetActive(false);
        }
    }
    public void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
        gameOverMenu.enabled = false;
        Time.timeScale = 1;
    }
    public void OpenGameOverMenu()
    {
        audioSource.Stop();
        gameOverMenu.enabled = true;
        Time.timeScale = 0;
    }
}
