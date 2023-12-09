using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Assets.Scripts
{
    public class TrashControl : MonoBehaviour
    {
        public GameObject[] trash;
        public static float spawnDelay = 15f;
        public int maxAllowedTrash = 4;
        static bool spawning = true;
        static bool gameLost = false;

        float time = 0;
        int seconds = 0;
        static List<GameObject> currentTrash = new List<GameObject>();

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
            }
        }

        void TrackTime()
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
        }

        public static void RemoveTrash(GameObject trash)
        {
            currentTrash.Remove(trash);
            Destroy(trash);
        }

        public static void StopSpawning()
        {
            spawning = false;
        }
        
        public static void StartSpawning()
        {
            spawning = true;
        }

        public static void SpawnFaster()
        {
            if (spawnDelay > 0) spawnDelay -= 0.2f;
        }

        public static bool GameLost()
        {
            return gameLost;
        }

        public static void ResetTrashSpawning()
        {
            spawnDelay = 15f;
            gameLost = false;
            currentTrash = new List<GameObject>();
            StartSpawning();
        }
    }
}