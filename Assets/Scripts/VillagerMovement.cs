using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{

	public float moveSpeed;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	private Rigidbody2D body;

	public bool isWalking;
	
	public float walkTime;				// How long the NPC should walk for
	private float walkCounter;			// Track how long the NPC has been walking each cycle
	public float waitTime;				// How long between walks
	private float waitCounter;			// Track how long the NPC has been waiting each cycle

	private int WalkDirection;			// 0 = up, 1 = right, 2 = down, 3 = left

	public Collider2D walkArea;

	private bool hasWalkArea;			// Track if the NPC is assigned a targeted movement area

	
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection();

		if (walkArea != null)
		{
			minWalkPoint = walkArea.bounds.min;
			maxWalkPoint = walkArea.bounds.max;
			hasWalkArea = true;
		}

    }

	private void StopWalking()
	{
		isWalking = false;
		waitCounter = waitTime; // Reset wait counter
	}

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
		{
			walkCounter -= Time.deltaTime;

			// Move in 
			switch (WalkDirection)
			{
				case 0:
					body.velocity = new Vector3(0, moveSpeed);

					if (hasWalkArea && transform.position.y > maxWalkPoint.y)
					{
						StopWalking();
					}

					break;
				case 1:
					body.velocity = new Vector3(moveSpeed, 0);

					if (hasWalkArea && transform.position.x > maxWalkPoint.x)
					{
						StopWalking();
					}
					break;
				case 2:
					body.velocity = new Vector3(0, -moveSpeed);

					if (hasWalkArea && transform.position.y < minWalkPoint.y)
					{
						StopWalking();
					}
					break;
				case 3:
					body.velocity = new Vector3(-moveSpeed, 0);

					if (hasWalkArea && transform.position.y < minWalkPoint.x)
					{
						StopWalking();
					}
					break;
			}

			if (walkCounter < 0)
			{
				StopWalking();
			}

		} else {
			waitCounter -= Time.deltaTime;

			body.velocity = Vector2.zero;

			if (waitCounter < 0) 		// Start walking again
			{
				ChooseDirection();
			}
			
		}
    }

	public void ChooseDirection()
	{
		WalkDirection = Random.Range(0, 4);

		isWalking = true;
		walkCounter = walkTime;
	}
}
