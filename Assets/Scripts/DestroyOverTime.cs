using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy a game object after an amount of time
public class DestroyOverTime : MonoBehaviour
{

	public float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
		
		if (timeToDestroy <= 0)
		{
			Destroy (gameObject);
		}
    }
}
