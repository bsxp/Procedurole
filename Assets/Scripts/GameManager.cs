using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	// Convert GameManager to a singleton
	public static GameManager instance = null;

	public DungeonManager dungeonScript;


    // Start is called before the first frame update
    void Awake()
    {
		dungeonScript = GetComponent<DungeonManager>();
		InitGame();
        // if (instance == null)
		// 	instance = this;
		// else if (instance != null)
		// 	Destroy(gameObject);
    }

    // Update is called once per frame
    void InitGame()
    {
        dungeonScript.SetupScene();
    }

	void Update()
	{

	}
}
