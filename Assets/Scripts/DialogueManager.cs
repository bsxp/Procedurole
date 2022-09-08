using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

	public GameObject dBox;					// Container for the dialogue
	public TMP_Text dText;					// Text

	public bool dialogueActive;				// Control if the dialogue box is open
	public string[] dialogueLines;			// Array of dialogue to store
	public int currentLine;					// Pointer to current dialogue line

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
		{
			currentLine++; 	// Next line of dialogue
		}

		if (currentLine >= dialogueLines.Length)
		{
			// Done with all the dialogue
			dBox.SetActive(false);
			dialogueActive = false;

			currentLine = 0;
		}

		dText.text = dialogueLines[currentLine]; // Set the text to display
    }
	public void ShowDialogue()
	{
		dialogueActive = true;
		dBox.SetActive(true);
	}
}
