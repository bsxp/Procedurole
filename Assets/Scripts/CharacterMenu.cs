using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{

	// Load the game with the selected character
	public void SelectCharacter() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	// Open up the character creation menu
	public void SelectCreateNewCharacter() {
		SceneManager.LoadScene(1);
	}

}
