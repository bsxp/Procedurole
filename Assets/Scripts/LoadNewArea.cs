using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

	public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.name);
		Debug.Log(levelToLoad);
		if (other.gameObject.name == "Player")
		{
			// Load into a new scene
			SceneManager.LoadScene(levelToLoad);
		}
	}
}
