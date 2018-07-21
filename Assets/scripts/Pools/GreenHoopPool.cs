using System;
using UnityEngine;

public class BlueHoopPool : MonoBehaviour
{
	public int currentObstacle = 0;
	public int poolSize = 5;
	public GameObject obstacle;
	public float timeSinceLastSpawn = 0;
	public float spawnRate = 4f;

	void Awake()
	{
		
	}
}

