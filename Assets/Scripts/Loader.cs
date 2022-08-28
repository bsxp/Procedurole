using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour

{
    public GameObject gameManager;
	
	// Create the game if it doesn't yet exist
    void Start()
    {
        if (GameManager.instance == null)
			Instantiate(gameManager);
    }
}
