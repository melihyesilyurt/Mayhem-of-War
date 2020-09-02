using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketScript : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button mainMenu;
    void Start()
    {
        startGame = startGame.GetComponent<Button>();
        mainMenu = mainMenu.GetComponent<Button>();
    }
    public void StartGame()
    {
        Application.LoadLevel(2);
    }
    public void GoMainMenu()
    {
        Application.LoadLevel(0);
    }
}
