using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

	public int playerMaxHealth;
	public int playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0) // player is out of health
		{
			gameObject.SetActive(false);

			// .. other 0 hp handlers .. end dungeon, revive, etc.
		}
    }

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		playerCurrentHealth = playerMaxHealth;
	}
}
