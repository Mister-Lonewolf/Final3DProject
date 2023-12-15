using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceInSpace : MonoBehaviour
{
    private Vector3 pos_ScriptObject;
    public bool enableAll = false;
    public float triggerY = 180.0f;
    private DestroyWithBoolean[] destroyScripts; // Lijst om DestroyWithBoolean-scripts op te slaan
    private MoveSprite[] moveSpriteScripts;
    private FollowPlayer followPlayer;
    private PlayerController playerController;
    private ChangeWeightRocket changeWeightRocket;
    private SpawnManager spawnManager;
    private Timer timer;
    private BackgroundMusic music;

    void Start()
    {
        pos_ScriptObject = transform.position;
        destroyScripts = FindObjectsOfType<DestroyWithBoolean>();
        moveSpriteScripts = FindObjectsOfType<MoveSprite>();
        followPlayer = FindObjectOfType<FollowPlayer>();
        playerController = FindObjectOfType<PlayerController>();
        changeWeightRocket = FindObjectOfType<ChangeWeightRocket>();
        spawnManager = FindObjectOfType<SpawnManager>();
        timer = FindObjectOfType<Timer>();
        music = FindObjectOfType<BackgroundMusic>();
    }

    void Update()
    {
        pos_ScriptObject = transform.position;

        if (pos_ScriptObject.y >= triggerY && !enableAll)
        {
            enableAll = true;
            Debug.Log("Once In Space triggered/enabled");

            if (playerController != null)
                playerController.enableSteering = true;

            if (music != null)
                music.enableMusic = true;

            if (timer != null)
                timer.startTimer = true;

            if (changeWeightRocket != null)
                changeWeightRocket.enableWeight = true;

            if (followPlayer != null)
                followPlayer.zoomEnabled = true;

            if (spawnManager != null)
                spawnManager.enableSpawning = true;

            // Activeer alle MoveSprite scripts in de array
            foreach (MoveSprite moveSpriteScript in moveSpriteScripts)
            {
                if (moveSpriteScript != null)
                    moveSpriteScript.activateScript = true;
            }
            foreach (DestroyWithBoolean destroyScript in destroyScripts)
            {
                if (destroyScript != null)
                    destroyScript.enableDestroy = true;
            }

            enabled = false; // disable script
        }
    }
}
