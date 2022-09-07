using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

	public int playerMaxHealth;
	public int playerCurrentHealth;

	private bool flashActive;				// Is the character currently taking damage?
	public float flashLength;				// How long we make the player flash for
	private float flashCounter;				// Count down how much time is left in the flashing

	private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
		playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0) // player is out of health
		{
			gameObject.SetActive(false);

			// .. other 0 hp handlers .. end dungeon, revive, etc.
		}

		if (flashActive) // Player is currently being hit
		{
			if (flashCounter > flashLength * 0.666f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} else if (flashCounter > flashLength * 0.333f) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			} else if (flashCounter > 0) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} else {
				// Ensure player is visible at the end of flashing
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}
		}

		flashCounter -= Time.deltaTime;
    }

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;

		flashActive = true;
		flashCounter = flashLength;
	}

	public void SetMaxHealth(){
		playerCurrentHealth = playerMaxHealth;
	}
}
