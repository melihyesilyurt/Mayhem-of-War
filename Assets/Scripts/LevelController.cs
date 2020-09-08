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
    private GameObject enemy;
    private float spawnTime=6;
    public bool spawnRigtNow;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject shieldSkeleton;
    [SerializeField] GameObject swordSkeleton;
    [SerializeField] GameObject traitorSoldier;
    [SerializeField] GameObject wizard;
    private float respawnTime;
    private int respawnNumber;
    [SerializeField] private int swordSkeletonPossibility;  
    [SerializeField] private int shieldSkeletonPossibility;
    [SerializeField] private int archerPossibility;
    [SerializeField] private int traitorSoldierPossibility;
    [SerializeField] private int wizardPossibility;
    void Awake()
    {
        Instance = GetComponent<LevelController>();
    }
    private void Start()
    {
        respawnTime = 5.00f;
        respawnNumber = 0;
    }
    private void Update()
    { 
        if (spawnRigtNow == true)
        {
            spawnTime += 1 * Time.deltaTime;
            if (spawnTime > respawnTime)
            {
                MusicManager.Instance.PlayEnemySpawnClip();
                Debug.Log("Spawn Vakti");
                int random = UnityEngine.Random.Range(0, Spawners.Length);
                int randomEnemy = UnityEngine.Random.Range(0, 100);
                if (randomEnemy < swordSkeletonPossibility)
                {
                    enemy = enemies[2];
                    Debug.Log(randomEnemy +" "+ enemies[2].name);
                }
                else if (randomEnemy< shieldSkeletonPossibility && randomEnemy>= swordSkeletonPossibility)
                {
                    enemy = enemies[1];
                    Debug.Log(randomEnemy + " " + enemies[1].name);
                }
                else if(randomEnemy < archerPossibility && randomEnemy >= shieldSkeletonPossibility)
                {
                    enemy = enemies[0];
                    Debug.Log(randomEnemy + " " + enemies[0].name);
                }
                else if (randomEnemy < traitorSoldierPossibility && randomEnemy >= archerPossibility)
                {
                    enemy = enemies[3];
                    Debug.Log(randomEnemy + " " + enemies[3].name);
                }
                else if (randomEnemy < wizardPossibility && randomEnemy >= traitorSoldierPossibility)
                {
                    enemy = enemies[4];
                    Debug.Log(randomEnemy + " " + enemies[4].name);
                }
                GameObject newEnemy = Instantiate(enemy, Spawners[random].transform.position, character.rotation);
                respawnNumber++;
                spawnTime = 0;
                if(respawnNumber==10 && respawnTime>2.00f)
                {
                    respawnNumber = 0;
                    respawnTime -= 0.05f;
                }
            }
        }
    }
}
