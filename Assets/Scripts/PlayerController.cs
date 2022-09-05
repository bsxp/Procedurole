using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		if (horizontal > 0.5f || horizontal < 0.5f) // Player is pressing right or left, respectively
		{
			transform.Translate(new Vector3(horizontal * moveSpeed * Time.deltaTime, 0f, 0f));
		}

		if (vertical > 0.5f || vertical < 0.5f) // Player is pressing right or left, respectively
		{
			transform.Translate(new Vector3(0f, vertical * moveSpeed * Time.deltaTime, 0f));
		}
    }
}
