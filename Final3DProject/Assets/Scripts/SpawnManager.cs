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
        while(true)
        {
                yield return new WaitForSeconds(updatedSpawnInterval);
            SpawnRandomEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos_MainCharacterObject = mainCharacter.transform.position;
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
        // compenseren dat je in beweging makkelijker wegkomt, dus meer spawnen als gevolg en over hele 'range'.
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
                    pos_EnemyObject = new Vector3(-spawnPos, Random.Range(-updatedSpawnRange, updatedSpawnRange), 0);
                    break;
                case MovementDirection.Right:
                    Debug.Log("spawned right");
                    pos_EnemyObject = new Vector3(spawnPos, Random.Range(-updatedSpawnRange, updatedSpawnRange), 0);
                    break;
                case MovementDirection.Up:
                    Debug.Log("spawned upstairs");
                    pos_EnemyObject = new Vector3(Random.Range(-updatedSpawnRange, updatedSpawnRange), spawnPos, 0);
                    break;
                case MovementDirection.Down:
                    Debug.Log("spawned downstairs");
                    pos_EnemyObject = new Vector3(Random.Range(-updatedSpawnRange, updatedSpawnRange), -spawnPos, 0);
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