using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

	public int damageToGive;
	private int currentDamage;				// Damage to give from the player's stats
	public GameObject damageBurst; 			// Damage burst object to render blood particles
	public GameObject damageNumber; 		// Floating damage number
	public Transform contactPoint; 			// Point to eminate the objects from

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


	// Destroy the enemy on hit
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy")
		{
			currentDamage = damageToGive + playerStats.currentAttack;

			// Deal damage to enemy
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			Instantiate(damageBurst, contactPoint.position, contactPoint.rotation);
			var clone = (GameObject) Instantiate(damageNumber, contactPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
		}
	}
}
