using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public Transform character;
    public GameObject[] enemies;
    public GameObject goldCoin;
    public GameObject[] Spawners;
    private Transform spawnPoint;
    private GameObject enemy;
    private float spawnTime=5;
    void Awake()
    {
        Instance = GetComponent<LevelController>();
    }
    private void Update()
    {
        spawnTime += (1 * Time.deltaTime);
        if(spawnTime>5.00f)
        {
            Debug.Log("Spawn Vakti");
            int random = UnityEngine.Random.Range(0, Spawners.Length);
            int randomEnemy = UnityEngine.Random.Range(0, enemies.Length);
            enemy = enemies[randomEnemy];
            GameObject newEnemy = Instantiate(enemy, Spawners[random].transform.position, character.rotation);
            spawnTime = 0;
        }
    }
}
