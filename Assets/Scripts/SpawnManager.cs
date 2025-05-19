using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawnList = new List<GameObject>();
    Vector3 spawnPos = new Vector3(25f,0f,0f);

    void Start()
    {
        StartCoroutine(nameof(CallerSpawnObstacle));
    }

    void Update()
    {
        
    }

    private System.Collections.IEnumerator CallerSpawnObstacle()
    {
        while (true) 
        {
            yield return new WaitForSeconds(GameController.TimeToSpawn);
            if (!GameController.gameOver) 
            {
                SpawnObstacle();   
            }
        }
    }

    void SpawnObstacle() 
    {
        if (spawnList.Count > 0) 
        {
            Instantiate(spawnList[Random.Range(0,spawnList.Count)], spawnPos, Quaternion.identity);
        }
    }

}
