using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public Transform character;
    //public List<GameObject> enemies;
    public GameObject goldCoin;
    void Awake()
    {
        Instance = GetComponent<LevelController>();
    }
}
