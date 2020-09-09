using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Canvas quitMenu;
    [SerializeField] private Button startText;
    [SerializeField] private Button exitText;
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }
    public void ExitPress()
    {
        MusicManager.Instance.PlayButtonClip();
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }
    public void NoPress()
    {
        MusicManager.Instance.PlayButtonClip();
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
    public void StartLevel()
    {
        MusicManager.Instance.PlayButtonClip();
        RouteManager.Instance.LoadMarketMenu();
    }
    public void ExitGame()
    {
        MusicManager.Instance.PlayButtonClip();
        Application.Quit();
    }
}
