using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawning = false;
    public GameObject[] enemyPrefabs;
    public GameObject mainCharacter;
    public float spawnRange = 30.0f;
    private float updatedSpawnRange;
    public float spawnPos = 30.0f;
    private float updatedSpawnInterval;
    public float startDelay = 2;
    public float spawnInterval = 1.0f;
    private Vector3 pos_MainCharacterObject;
    private Vector3 pos_EnemyObject;
    public MovementDirection direction;
    public bool spawnAccelerated = false;

    public enum MovementDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    void Start()
    {
        StartCoroutine(spawnWave());
        direction = GetRandomDirection();
    }

    IEnumerator spawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(updatedSpawnInterval);
            SpawnRandomEnemy();
        }
    }

    void Update()
    {
        pos_MainCharacterObject = mainCharacter != null ? mainCharacter.transform.position : Vector3.zero;
        spawnAccelerated = Input.GetKey(KeyCode.Space);
        if (spawnAccelerated)
        {
            updatedSpawnInterval = spawnInterval * 0.65f;
            updatedSpawnRange = spawnRange * 1.9f;
        }
        else
        {
            updatedSpawnInterval = spawnInterval;
            updatedSpawnRange = spawnRange;
        }
    }

    void SpawnRandomEnemy()
    {
        if (enableSpawning && mainCharacter != null)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Quaternion mainCharacterRotation = mainCharacter.transform.rotation;
            direction = GetRandomDirection();
            switch (direction)
            {
                case MovementDirection.Left:
                    pos_EnemyObject = new Vector3(-spawnPos, Random.Range(-updatedSpawnRange, updatedSpawnRange), 0);
                    break;
                case MovementDirection.Right:
                    pos_EnemyObject = new Vector3(spawnPos, Random.Range(-updatedSpawnRange, updatedSpawnRange), 0);
                    break;
                case MovementDirection.Up:
                    pos_EnemyObject = new Vector3(Random.Range(-updatedSpawnRange, updatedSpawnRange), spawnPos, 0);
                    break;
                case MovementDirection.Down:
                    pos_EnemyObject = new Vector3(Random.Range(-updatedSpawnRange, updatedSpawnRange), -spawnPos, 0);
                    break;
            }
            pos_EnemyObject += pos_MainCharacterObject;

            // Check if the mainCharacter is not null before attempting to instantiate
            if (mainCharacter != null)
            {
                Instantiate(enemyPrefabs[enemyIndex], pos_EnemyObject, enemyPrefabs[enemyIndex].transform.rotation);
            }
        }
    }

    MovementDirection GetRandomDirection()
    {
        // Enum.GetValues geeft een array van alle mogelijke waarden in de enum
        MovementDirection[] directions = (MovementDirection[])System.Enum.GetValues(typeof(MovementDirection));

        // Kies willekeurig een element uit de array
        return directions[Random.Range(0, directions.Length)];
    }
}
