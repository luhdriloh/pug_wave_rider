using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {
	public int currentObstacle = 0;
	public int poolSize = 5;
	public GameObject obstacle;
	public float timeSinceLastSpawn = 0;
	public float spawnRate = 4f;

	public ObjectPool pool;

	// Use this for initialization
	void Awake () {
		PoolConfiguration config = new PoolConfiguration
		{
			prefab = obstacle,
			prefabTagName = "Enemy",
			poolSize = poolSize,
			initialPosition = GameConstants.poolStartPosition

		};

		pool = new ObjectPool (config);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameover) {
			return;
		}

		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn >= spawnRate) {
			timeSinceLastSpawn = 0;
			float randomX = Random.Range (GameConstants.minX, GameConstants.maxX);
			pool.BorrowFromPool().transform.position = new Vector2 (randomX, GameConstants.spawnY);
			currentObstacle = (currentObstacle + 1) % poolSize;
		}
	}
}
