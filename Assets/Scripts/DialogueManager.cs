using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

	public GameObject dBox;					// Container for the dialogue
	public TMP_Text dText;					// Text

	public bool dialogueActive;				// Control if the dialogue box is open

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
		{
			dBox.SetActive(false);
			dialogueActive = false;
		}
    }

	public void ShowBox(string dialogue)
	{
		dialogueActive = true;
		dBox.SetActive(true);
		dText.text = dialogue;
	}
}
