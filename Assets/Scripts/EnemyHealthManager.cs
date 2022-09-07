using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyMaxHealth;
	public int enemyCurrentHealth;

	private PlayerStats playerStats;	// Reference to player stats

	public int expToGive;				// Experience the enemy will award on death

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;

		playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0) // enemy is out of health
		{
			Destroy(gameObject);

			playerStats.AddExperience(expToGive);
		}
    }

	public void HurtEnemy(int damageToGive)
	{
		enemyCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		enemyCurrentHealth = enemyMaxHealth;
	}
}
