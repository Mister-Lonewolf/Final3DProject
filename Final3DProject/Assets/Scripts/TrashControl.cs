using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class TrashControl : MonoBehaviour
    {
        public GameObject[] trash;
        public static float spawnDelay = 15f;
        public int maxAllowedTrash = 4;
        
        private bool spawning = true;
        private bool gameLost = false;
        private float time = 0;
        private int seconds = 0;
        private static List<GameObject> currentTrash = new();

        private void Start()
        {
            currentTrash.Clear();
            spawnDelay = 15f;
        }

        private void Update()
        {
            TrackTime();
            if (spawning && currentTrash.Count <= 1000 && seconds >= spawnDelay)
            {
                SpawnTrash();
                Debug.Log(seconds + " seconds have past");
                time = 0;
            }
            if (currentTrash.Count > maxAllowedTrash && !gameLost)
            {
                StopSpawning();
                gameLost = true;
                Debug.Log("gamelost");
            }
        }

        private void TrackTime()
        {
            time += Time.deltaTime;
            seconds = (int)time % 60;
        }

        private void SpawnTrash()
        {
            int randomTrash = Random.Range(0, trash.Length);
            Vector3[] position = {
                    new Vector3(Random.Range(1.25f, 10.09f), 2, Random.Range(-6.25f, 6.25f)), // double -> more probabillity to choose it 
                    new Vector3(Random.Range(-10.06f, -1.25f), 2, Random.Range(-6.25f, 6.25f)),
                    new Vector3(Random.Range(-13.8f, -10.06f), 2, Random.Range(-6.25f, -1.15f)),
                    new Vector3(Random.Range(1.25f, 10.09f), 2, Random.Range(-6.25f, 6.25f)), // double
                    new Vector3(Random.Range(-10.06f, -1.25f), 2, Random.Range(-6.25f, 6.25f)),
                    new Vector3(Random.Range(1.25f, 10.09f), 2, Random.Range(-6.25f, 6.25f)), // double
                    new Vector3(Random.Range(-10.06f, -1.25f), 2, Random.Range(-6.25f, 6.25f))
                };
            int randomPosition = Random.Range(0, position.Length);
            currentTrash.Add(Instantiate(trash[randomTrash], position[randomPosition], Quaternion.identity));
            Debug.Log("current amount of trash: " + currentTrash.Count);
        }

        public void RemoveTrash(GameObject trash)
        {
            currentTrash.Remove(trash);
            Destroy(trash);
        }

        public void StopSpawning()
        {
            spawning = false;
        }
        
        public void StartSpawning()
        {
            spawning = true;
        }

        public void SpawnFaster()
        {
            if (spawnDelay > 0) spawnDelay -= 0.2f;
        }

        public bool GameLost()
        {
            return gameLost;
        }
    }
}