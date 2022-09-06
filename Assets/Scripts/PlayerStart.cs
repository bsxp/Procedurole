using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{

	private PlayerController player;
	private CameraController cam;

	public Vector2 startDirection;

    // Start is called before the first frame update
    void Start()
    {
		// Make the player point the same as our start point
        player = FindObjectOfType<PlayerController>();
		player.transform.position = transform.position;
		player.lastMove = startDirection;

		// Make the camera position the same as our start point, keep z index
		cam = FindObjectOfType<CameraController>();
		cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
