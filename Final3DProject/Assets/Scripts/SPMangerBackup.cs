using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPMangerBackup : MonoBehaviour
{
    public bool enableSpawning = false;
    public GameObject[] enemyPrefabs;
    public GameObject mainCharacter;
    public float spawnRange = 70.0f;
    public float spawnPos = 30.0f;
    public float startDelay = 2;
    public float spawnInterval = 0.8f;
    private Vector3 pos_MainCharacterObject;
    private Vector3 pos_EnemyObject;
    public MovementDirection direction;

    public enum MovementDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, Random.Range(spawnInterval, spawnInterval * 1.3f));
        direction = GetRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        pos_MainCharacterObject = mainCharacter.transform.position;
    }
    void SpawnRandomEnemy()
    {
        if (enableSpawning)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Quaternion mainCharacterRotation = mainCharacter.transform.rotation;
            direction = GetRandomDirection();
            switch (direction)
            {
                case MovementDirection.Left:
                    Debug.Log("spawned left");
                    pos_EnemyObject = new Vector3(-spawnPos, Random.Range(-spawnRange, spawnRange), 0);
                    break;
                case MovementDirection.Right:
                    Debug.Log("spawned right");
                    pos_EnemyObject = new Vector3(spawnPos, Random.Range(-spawnRange, spawnRange), 0);
                    break;
                case MovementDirection.Up:
                    Debug.Log("spawned upstairs");
                    pos_EnemyObject = new Vector3(Random.Range(-spawnRange, spawnRange), spawnPos, 0);
                    break;
                case MovementDirection.Down:
                    Debug.Log("spawned downstairs");
                    pos_EnemyObject = new Vector3(Random.Range(-spawnRange, spawnRange), -spawnPos, 0);
                    break;
            }
            pos_EnemyObject += pos_MainCharacterObject;
            // pos_EnemyObject = mainCharacter.transform.position + mainCharacterRotation * pos_EnemyObject;
            Instantiate(enemyPrefabs[enemyIndex], pos_EnemyObject, enemyPrefabs[enemyIndex].transform.rotation);
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