using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {
	public int poolSize = 5;
	public GameObject obstacle;
	public float timeSinceLastSpawn = 0;
	public float spawnRateMin = .5f;
	public float spawnRateMax = 5f;
	public float timeLeftForNextSpawn;

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

		System.DateTime now = System.DateTime.UtcNow;
		double secondsSinceLastSpawn = (now - GameConstants.timeOfLastSpawn).TotalSeconds;

		if (secondsSinceLastSpawn < GameConstants.timeBetweenSpawns)
		{
			return;
		}

		timeSinceLastSpawn += Time.deltaTime;

		if (TimeForNextSpawn()) {
			float randomX = Random.Range (GameConstants.minX, GameConstants.maxX);
			pool.BorrowFromPool().transform.position = new Vector2 (randomX, GameConstants.spawnY);
			GameController.instance.SetTimeOfLastSpawn (now);
			timeSinceLastSpawn = 0;
			ResetTimeForNextSpawn ();
		}
	}


	private bool TimeForNextSpawn() {
		return timeSinceLastSpawn >= timeLeftForNextSpawn;
	}

	private void ResetTimeForNextSpawn() {
		timeLeftForNextSpawn = UnityEngine.Random.Range (spawnRateMin, spawnRateMax);
	}
}
