using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public int currentLevel; 			// Player's current level
	public int currentExp;				// Player's current experience
	public int[] toLevelUp;				// Array of experience thresholds for levels

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= toLevelUp[currentLevel])
		{
			currentLevel++;
		}
    }

	// Give experience to the user
	public void AddExperience(int experienceToAdd)
	{
		currentExp += experienceToAdd;
	}
}
