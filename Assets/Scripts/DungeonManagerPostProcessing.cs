using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edgar.Unity;

public class DungeonManagerPostProcessing : DungeonGeneratorPostProcessingComponentGrid2D
{

	// Wrapper for the dungeon object
	[SerializeField]
	public GameObject generatedLevel;
	// Scale to apply to the dungeon
	[SerializeField]
	public Vector3 scale = new Vector3(0, 0, 0);

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
		generatedLevel.transform.localScale = scale;
		Debug.Log(generatedLevel.transform.localScale);
    }
}