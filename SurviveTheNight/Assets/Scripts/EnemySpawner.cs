using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public Transform playerTransform;


    float timer = 0f;
    float spawnerInterval = 3f;

    public int maxEnemies = 5;

    public void destroyEnemy(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnerInterval && spawnedEnemies.Count < maxEnemies)
        {
            
            float x = Random.Range(-8f, 8f);
            float z = Random.Range(-8, 8f);
            Vector3 position = new Vector3(x, 0.5f, z);
            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.GetComponent<EnemyFollow>().target = playerTransform;
            enemy.GetComponent<EnemyFollow>().spawner = this;
            spawnedEnemies.Add(enemy);
            timer = 0f;
        }
    }
}
