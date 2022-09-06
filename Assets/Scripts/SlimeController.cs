using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{

	public float moveSpeed;
	public Rigidbody2D body;
	private bool isMoving;
	public float timeBetweenMove;             	// Time between each movement for the slime
	public float timeToMove;                  	// How long the slime moves for
	private float timeBetweenMoveCounter;     	// Interval between moves
	private float timeToMoveCounter;          	// Countdown time between moves
	private Vector3 moveDirection;				// Direction for the slime to move
	public float waitToReload;             	 	// How long to wait before reloading collided-with objects
	private bool reloading;                	   	// Handle level reloading
	private GameObject player;             	   	// Player object

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); // set up interval counter
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f); // set up countdown timer for movement
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
		{
			timeToMoveCounter -= Time.deltaTime;
			body.velocity = moveDirection;

			if (timeToMoveCounter < 0)
			{
				isMoving = false;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} else { // Not moving
			timeBetweenMoveCounter -= Time.deltaTime;
			body.velocity = Vector2.zero; // no velocities when not moving

			if (timeBetweenMoveCounter < 0f) // If we've gone past the amount of time we're not moving
			{
				isMoving = true; // start moving
				timeToMoveCounter =  Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f); //reset counter

				moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f); // Pick a random direction to move in
			}
		}

		if (reloading)
		{
			waitToReload -= Time.deltaTime;

			if (waitToReload < 0)
			{
				// Reload the whole level
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				player.SetActive(true);
			}
		}

    }

	// Handle collision with the player
	private void OnCollisionEnter2D(Collision2D other) {
		// if (other.gameObject.name == "Player") // If the slime collides with the player
		// {
		// 	other.gameObject.SetActive(false); // Deactivate the player
		// 	reloading = true;
		// 	player = other.gameObject;
		// }
	}
}
