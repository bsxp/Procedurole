using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

	public string levelToLoad;

	public string exitPoint; // Name of the exit point

	private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player")
		{
			// Load into a new scene
			SceneManager.LoadScene(levelToLoad);

			// Set the player's spawn/entry
			player.startPoint = exitPoint;
		}
	}
}
