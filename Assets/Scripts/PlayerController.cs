using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;

	private Animator anim;

	private bool playerMoving;

	private Vector2 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		playerMoving = false;

		if (horizontal > 0.5f || horizontal < -0.5f) // Player is pressing right or left, respectively
		{
			transform.Translate(new Vector3(horizontal * moveSpeed * Time.deltaTime, 0f, 0f));
			playerMoving = true;
			lastMove = new Vector2(horizontal, 0f);
		}

		if (vertical > 0.5f || vertical < -0.5f) // Player is pressing right or left, respectively
		{
			transform.Translate(new Vector3(0f, vertical * moveSpeed * Time.deltaTime, 0f));
			playerMoving = true;
			lastMove = new Vector2(0f, vertical);
		}

		anim.SetFloat("MoveX", horizontal);
		anim.SetFloat("MoveY", vertical);
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
    }
}
