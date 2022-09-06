using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 5;

	private Animator anim;
	private Rigidbody2D body;

	private bool playerMoving;

	public Vector2 lastMove;

	// All player objects inherit this
	private static bool playerExists;

	private bool attacking;
	public float attackTime; // how long the attack lasts 
	private float attackTimeCounter; // track attack duration

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();

		if (!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
		
    }

    // Update is called once per frame
    void Update()
    {
		HandleMovement();
    }

	void HandleMovement() {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");


		playerMoving = false;

		if (!attacking)
		{
			if (horizontal > 0.5f || horizontal < -0.5f) // Player is pressing right or left, respectively
			{
				// transform.Translate(new Vector3(horizontal * moveSpeed * Time.deltaTime, 0f, 0f));
				body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);
				playerMoving = true;
				lastMove = new Vector2(horizontal, 0f);
			}

			if (vertical > 0.5f || vertical < -0.5f) // Player is pressing right or left, respectively
			{
				// transform.Translate(new Vector3(0f, vertical * moveSpeed * Time.deltaTime, 0f));
				body.velocity = new Vector2(body.velocity.x, vertical * moveSpeed);
				playerMoving = true;
				lastMove = new Vector2(0f, vertical);
			}

			if (horizontal < 0.5 && horizontal > -0.5)
			{
				body.velocity = new Vector2(0f, body.velocity.y);
			}

			if (vertical < 0.5 && vertical > -0.5)
			{
				body.velocity = new Vector2 (body.velocity.x, 0f);
			}
		}

		HandleAttack();

		anim.SetFloat("MoveX", horizontal);
		anim.SetFloat("MoveY", vertical);
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}

	// Handle attack damage and animations
	void HandleAttack() {

		if (Input.GetKeyDown(KeyCode.J))
		{
			attackTimeCounter = attackTime;
			attacking = true;

			body.velocity = Vector2.zero;

			anim.SetBool("PlayerAttacking", true);
		}

		// Decrement remaining time
		if (attackTimeCounter > 0)
		{
			attackTimeCounter -= Time.deltaTime;
		}

		// End attack
		if (attackTimeCounter <= 0)
		{
			attacking = false;
			anim.SetBool("PlayerAttacking", false);
		}
	}

}
