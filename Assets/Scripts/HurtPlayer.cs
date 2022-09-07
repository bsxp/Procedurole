using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

	public int damageToGive;
	public GameObject damageNumber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Handle collision with the player
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Player") // If the slime collides with the player
		{
			other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);

			var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
		}
	}
}
