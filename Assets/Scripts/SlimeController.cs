using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

	public float moveSpeed;
	public Rigidbody2D body;
	private bool isMoving;
	public float timeBetweenMove;             // Time between each movement for the slime
	public float timeToMove;                  // How long the slime moves for
	private float timeBetweenMoveCounter;      // Interval between moves
	private float timeToMoveCounter;          // Countdown time between moves
	private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
		timeBetweenMoveCounter = timeBetweenMove; // set up interval counter
		timeToMoveCounter = timeToMove; // set up countdown timer for movement
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
				timeBetweenMoveCounter = timeBetweenMove;
			}

		} else { // Not moving
			timeBetweenMoveCounter -= Time.deltaTime;
			body.velocity = Vector2.zero; // no velocities when not moving

			if (timeBetweenMoveCounter < 0f) // If we've gone past the amount of time we're not moving
			{
				isMoving = true; // start moving
				timeToMoveCounter = timeToMove; //reset counter

				moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f); // Pick a random direction to move in
			}
		}
    }
}
