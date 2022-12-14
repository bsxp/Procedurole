using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

	public string dialogue;
	private DialogueManager dManager;

	public string[] dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        dManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player")
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				if (!dManager.dialogueActive)
				{
					dManager.dialogueLines = dialogueLines;
					dManager.currentLine = 0;
					dManager.ShowDialogue(); // Show dialogue box if it's not already on screen
				}
			}
		}
	}
}
