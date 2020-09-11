using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MarketScript : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button mainMenu;
    [SerializeField] private Text goldAmountText;
    [SerializeField] private Button yesText;
    [SerializeField] private Button noText;
    [SerializeField] private Canvas areYouSure;
    [SerializeField] private Canvas youHaveNoMoney;
    [SerializeField] private Button closeButton;
    private int characterid;
    private int mapid = 0;
    private GameObject choosenLock;
    private int money;
    private int valueOfLock;
    private string bought ="bought";
    private int godGift =1000000;
    private void Awake()
    {
        PlayerPrefs.SetInt("GoldCoin", godGift);
        GameObject[] locks;
        locks = GameObject.FindGameObjectsWithTag("Lock");
        foreach (GameObject lockImage in locks)
        {
            if(PlayerPrefs.GetString(lockImage.name) == bought)
            {
                lockImage.SetActive(false);
            }
            else
            {
                lockImage.SetActive(true);
            }
        }
    }
    void Start()
    {
        characterid = 0;
        money = PlayerPrefs.GetInt("GoldCoin");
        areYouSure.enabled = false;
        youHaveNoMoney.enabled = false;
    }
    public void StartGame()
    {
        MusicManager.Instance.PlayButtonClip();
        if (mapid != 0)
        {
            if (characterid != 0)
            {
                if(mapid==2)
                {
                    RouteManager.Instance.LoadFirstMap();
                }
               else if (mapid == 3)
                {
                    RouteManager.Instance.LoadSecondMap();
                }
                PlayerPrefs.SetInt("SelectCharacter", characterid);
            }
        }
    }

    public void GoMainMenu()
    {
        MusicManager.Instance.PlayButtonClip();
        RouteManager.Instance.LoadMainMenu();
    }
    public void YesPress()
    {
        MusicManager.Instance.PlayButtonClip();
        if (money>=valueOfLock)
        {
            choosenLock.SetActive(false);
            money -= valueOfLock;
            PlayerPrefs.SetInt("GoldCoin", money);
            PlayerPrefs.SetString(choosenLock.name,bought);
        }
        else
        {
            youHaveNoMoney.enabled = true;
        }
        areYouSure.enabled = false;    
    }
    public void NoPress()
    {
        MusicManager.Instance.PlayButtonClip();
        areYouSure.enabled = false;
    }
    public void close()
    {
        MusicManager.Instance.PlayButtonClip();
        youHaveNoMoney.enabled = false;
    }
    private void Update()
    {
        goldAmountText.text =""+ money;
        PlayerPrefs.SetInt("GoldCoin", money);
    }
    public void Lock(GameObject takenLock)
    {
        MusicManager.Instance.PlayButtonClip();
        choosenLock = takenLock;
        areYouSure.enabled = true;
        valueOfLock = takenLock.GetComponent<Lock>().value;
    }
    public void ChooseMap(GameObject choosenMap)
    {
        MusicManager.Instance.PlayButtonClip();
        GameObject[] maps;
        maps = GameObject.FindGameObjectsWithTag("Maps");
        foreach (GameObject map in maps)
        {
            map.GetComponent<Outline>().enabled = false;
        }
        if (choosenMap.name=="Map1")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 2;
        }
        else if (choosenMap.name == "Map2")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 3;
        }
        else if (choosenMap.name == "Map3")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 4;
        }
        else if (choosenMap.name == "Map4")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 5;
        }
        else if (choosenMap.name == "Map5")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 6;
        }
    }
    public void ChooseCharacter(GameObject choosenCharacter)
    {
        MusicManager.Instance.PlayButtonClip();
        GameObject[] characters;
        characters = GameObject.FindGameObjectsWithTag("Characters");
        foreach (GameObject character in characters)
        {
            character.GetComponent<Outline>().enabled = false;
        }
        if (choosenCharacter.name == "Old Knight")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 1;
        }
        else if (choosenCharacter.name == "Young Warrior")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 2;
        }
        else if (choosenCharacter.name == "Female Knight")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 3;
        }
        else if (choosenCharacter.name == "Alone Samurai")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 4;
        }
        else if (choosenCharacter.name == "King")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 5;
        }
    }
}
