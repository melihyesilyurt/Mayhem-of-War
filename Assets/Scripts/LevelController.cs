using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public Transform character;
    //public List<GameObject> enemies;
    void Awake()
    {
        Instance = GetComponent<LevelController>();
    }
}
