﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour {
	
	public enum deathAction {loadLevelWhenDead,doNothingWhenDead};
	
	public float healthPoints = 3f;
	public float respawnHealthPoints = 1f;		//base health points
	
	public int numberOfLives = 1;					//lives and variables for respawning
	public bool isAlive = true;
	public TextMeshProUGUI healthText;

	public GameObject explosionPrefab;
	public GameObject GameOverMenu;
	
	public deathAction onLivesGone = deathAction.doNothingWhenDead;

	public string LevelToLoad = "";
    private BackgroundMusic backgroundMusicScript;
    private Vector3 respawnPosition;
	private Quaternion respawnRotation;
	

	// Use this for initialization
	void Start () 
	{
		// store initial position as respawn location
        respawnPosition = transform.position;
		respawnRotation = transform.rotation;
		
		if (LevelToLoad=="") // default to current scene 
		{
			LevelToLoad = SceneManager.GetActiveScene().name;
		}
		healthText.text = "Shield: " + healthPoints;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (healthPoints <= 0) {				// if the object is 'dead'
			numberOfLives--;					// decrement # of lives, update lives GUI
			
			if (explosionPrefab!=null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			
			if (numberOfLives > 0) { // respawn
				transform.position = respawnPosition;	// reset the player to respawn position
				transform.rotation = respawnRotation;
				healthPoints = respawnHealthPoints;	// give the player full health again
			} else { // here is where you do stuff once ALL lives are gone)
				isAlive = false;
				
				switch(onLivesGone)
				{
				case deathAction.loadLevelWhenDead:
					SceneManager.LoadScene(LevelToLoad);
					break;
				case deathAction.doNothingWhenDead:
					// do nothing, death must be handled in another way elsewhere
					break;
				}
                GameObject mainCamera = Camera.main.gameObject;
                backgroundMusicScript = mainCamera.GetComponent<BackgroundMusic>();
                if (backgroundMusicScript != null)
                {
                    backgroundMusicScript.StopMusic();
                }
                Vector3 GOcurrentPosition = GameOverMenu.transform.position; // move game over menu back to screen
                GOcurrentPosition.x -= 6666f;
                GameOverMenu.transform.position = GOcurrentPosition;
                Destroy(gameObject);
			}
		}
	}
	
	public void ApplyDamage(float amount)
	{	
		healthPoints = healthPoints - amount;
        healthText.text = "Shield: " + healthPoints;

    }
	
	public void ApplyHeal(float amount)
	{
		healthPoints = healthPoints + amount;
        healthText.text = "Shield: " + healthPoints;
		
    }

	public void ApplyBonusLife(int amount)
	{
		numberOfLives = numberOfLives + amount;
	}
	
	public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation) {
		respawnPosition = newRespawnPosition;
		respawnRotation = newRespawnRotation;
	}
}