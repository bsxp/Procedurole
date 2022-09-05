using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	// Convert GameManager to a singleton
	public static GameManager instance = null;

	public DungeonManager dungeonScript;

	// Manage the starting of the dungeon
	private Button startDungeonButton; 


    // Start is called before the first frame update
    void Awake()
    {
		
		dungeonScript = GetComponent<DungeonManager>();
		InitGame();
        // if (instance == null)
		// 	instance = this;
		// else if (instance != null)
		// 	Destroy(gameObject);

		// Get the start game button
		startDungeonButton = GameObject.FindGameObjectWithTag("Start button").GetComponent<Button>();
		startDungeonButton.onClick.AddListener(() => StartDungeon());

    }

    // Update is called once per frame
    void InitGame()
    {
        dungeonScript.SetupScene();
    }

	void Update()
	{

	}

	private void StartDungeon() {
		Debug.Log("STARTING GAME!");
		SceneManager.LoadScene("Game Scene");
	}
}
