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
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Canvas gameOverMenu;
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button goMainMenuButton;
    public Text scoreText;
    public Text goldText;
    public Text scoreTextPanel;
    public Text HighScoreTextPanel;
    private AudioSource audioSource;
    private int characterid;
    [SerializeField] private Text avatarName;
    [SerializeField] private Image avatarPhoto;
    [SerializeField] private Sprite oldKnightPhoto;
    [SerializeField] private Sprite youngWarriorPhoto;
    [SerializeField] private Sprite femaleKnightPhoto;
    [SerializeField] private Sprite aloneSamuraiPhoto;
    [SerializeField] private Sprite kingPhoto;
    public Image healthBar;
    public Image staminaBar;
    public Button jumpButton;
    public Button attackButton;
    public VariableJoystick joystick;
    private GameObject character;
    private Character characterScript;
    private PlayerCombat playerCombat;
    void Start()
    {
        character = GetComponent<CharacterFollower>().character;
        Instance = GetComponent<GameInterFace>();
        characterid = PlayerPrefs.GetInt("SelectCharacter");
        Debug.Log(characterid);

        characterScript = character.GetComponent<Character>();
        playerCombat = character.GetComponent<PlayerCombat>();
        gameOverMenu.enabled = false;
        pauseMenu.enabled = false;
        settingsMenu.SetActive(false);
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
        CharacterUI();
       
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
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenSettingsMenu()
    {
        MusicManager.Instance.PlayButtonClip();
        settingsMenu.SetActive(true);
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
        pauseButton.enabled = false;
        audioSource.Stop();
        gameOverMenu.enabled = true;
        Time.timeScale = 0;
    }
    public void JumpButton()
    {
        characterScript.Jump();
    }
    public void AttackButton()
    {
        playerCombat.Attack();
    }
    private void CharacterUI()
    {
        if (characterid == 1)
        {
            avatarName.text = "Old Knight";
            avatarPhoto.sprite = oldKnightPhoto;
        }
        else if (characterid == 2)
        {
            avatarName.text = "Young Warrior";
            avatarPhoto.sprite = youngWarriorPhoto;
        }
        else if (characterid == 3)
        {
            avatarName.text = "Female Knight";
            avatarPhoto.sprite = femaleKnightPhoto;
        }
        else if (characterid == 4)
        {
            avatarName.text = "Alone Samurai";
            avatarPhoto.sprite = aloneSamuraiPhoto;
        }
        else if (characterid == 5)
        {
            avatarName.text = "King";
            avatarPhoto.sprite = kingPhoto;
        }
    }
}
