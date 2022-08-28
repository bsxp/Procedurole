using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character : MonoBehaviour
{

	// Types of characters 
	public enum CharacterType
	{
		NpcCharacter = 0, // people in towns, quest givers, damsels in distress, etc.
		PlayerCharacter = 1, // user-controlled characters
		MonsterCharacter = 2 // characters meant specifically for combat with the user
	}

	// The character's speed
	private int speed;

	// The character's type (npc, monster, or player)
	public readonly CharacterType Type;

	// The character's current level
	public int CharacterLevel { get; private set; }

	// The character's RPG stats
	public int Strength { get; private set; }
	public int Dexterity { get; private set; }
	public int Constitution { get; private set; }
	public int Intelligence { get; private set; }
	public int Wisdom { get; private set; }
	public int Charisma { get; private set; }

	// Tracks the character's current health
	public int currentHealth { get; private set; }

	// Tracks the character's temporary health
	public int temporaryHealth { get; private set; }

	// The multiplier by which base health is calculated
	// e.g. Character level x HealthMultiplier = hitpoints
	private int HealthMultiplier;

	// Health to add or subtract from this particular character
	// after multiplying their character level by their hit die
	private int HealthModifier;

	// Add health to a character, flowing into temporary health if necessary
	int addHealth(int amount, bool overflows = false)
	{

		if (amount <= 0) // Can't add less than 0
			return this.currentHealth;

		int maxHealth = (HealthMultiplier * CharacterLevel) + HealthModifier; // maximum possible character health
		int overheal = currentHealth + amount - maxHealth; // potential health overflow into temporary health

		this.currentHealth = System.Math.Min(currentHealth + amount, maxHealth); // set to new HP, or max HP
		

		if (overflows == true) // If it's possibly a temporary heal, return 
			this.temporaryHealth = overheal;

		return this.currentHealth + this.temporaryHealth;


	}

	// Take away health from a character
	int removeHealth(int amount)
	{

		if (amount <= 0) // Can't remove lass than 0
			return this.currentHealth;

		int remainder;

		if (temporaryHealth > 0) // If the character has temporary health, take away that first
			remainder = temporaryHealth - amount; // Calculate temp health is left over after we take damage?
		else
			remainder = amount;

		if (remainder > 0) // If there is still health to take away
			this.currentHealth -= System.Math.Max(this.currentHealth - remainder, 0);

		return this.currentHealth;
	}

	// Move the character
	// protected virtual void Move(int direction)
	// {
	// 	// Move the character
	// 	transform.Translate(direction  * speed);
	// }
}