using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouteManager : MonoBehaviour
{
    public static RouteManager Instance;
    private const string MAIN_MENU_NAME = "Main Menu";
    private const string FIRST_MAP_NAME = "First Map";
    private const string SECOND_MAP_NAME = "Map 2";
    private const string MARKET_MENU_NAME = "Market Menu";
    void Start()
    {
        Instance = GetComponent<RouteManager>();
        DontDestroyOnLoad(gameObject);
    }
    public void LoadMainMenu()
    {
        LoadScene(MAIN_MENU_NAME);
    }
    public void LoadFirstMap()
    {
        LoadScene(FIRST_MAP_NAME);
    }
    public void LoadSecondMap()
    {
        LoadScene(SECOND_MAP_NAME);
    }
    public void LoadMarketMenu()
    {
        LoadScene(MARKET_MENU_NAME);
    }
    private void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
