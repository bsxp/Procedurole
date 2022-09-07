using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

	public int damageToGive;
	private int currentDamage;					// Damage to give the player from the enemy
	public GameObject damageNumber;

	private PlayerStats playerStats;



    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Handle collision with the player
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Player") // If the slime collides with the player
		{

			currentDamage = Mathf.Max(damageToGive - playerStats.currentDefence, 1); // Player always takes 1 damage

			other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);

			var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
		}
	}
}
