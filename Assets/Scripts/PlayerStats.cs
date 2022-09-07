using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public int currentLevel; 			// Player's current level
	public int currentExp;				// Player's current experience
	public int[] toLevelUp;				// Array of experience thresholds for levels

	public int[] HPLevels;
	public int[] attackLevels;
	public int[] defenceLevels;

	public int currentHP;
	public int currentAttack;
	public int currentDefence;

	private PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = HPLevels[1];
		currentAttack = attackLevels[1];
		currentDefence = defenceLevels[1];

		playerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= toLevelUp[currentLevel])
		{
			LevelUp();
		}
    }

	// Give experience to the user
	public void AddExperience(int experienceToAdd)
	{
		currentExp += experienceToAdd;
	}

	public void LevelUp()
	{
		currentLevel++;
		currentHP = HPLevels[currentLevel];

		playerHealth.playerMaxHealth = currentHP;

		Debug.Log("Before");
		Debug.Log(playerHealth.playerCurrentHealth);
		Debug.Log(currentHP);
		Debug.Log(HPLevels[currentLevel - 1]);
		Debug.Log("Difference");
		Debug.Log((currentHP - HPLevels[currentLevel - 1]));

		playerHealth.playerCurrentHealth += (currentHP - HPLevels[currentLevel - 1]);

		Debug.Log("After");
		Debug.Log(playerHealth.playerCurrentHealth);

		currentAttack = attackLevels[currentLevel];
		currentDefence = defenceLevels[currentLevel];
	}
}
