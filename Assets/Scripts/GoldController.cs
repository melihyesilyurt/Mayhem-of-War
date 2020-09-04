using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    private int goldCoin;
    public static GoldController Instance;
    public int GoldCoin
    {
        get { return goldCoin; }
        set { goldCoin = value; }
    }
    void Awake()
    {
        goldCoin = PlayerPrefs.GetInt("GoldCoin");
        Instance = GetComponent<GoldController>();
    }
}
