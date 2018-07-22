using System.Collections.Generic;
using UnityEngine;

public class GreenHoopPool : MonoBehaviour
{
	public int currentObstacle = 0;
	public int poolSize = 5;
	public GameObject prefab;
	public float timeSinceLastSpawn = 0;
	public float spawnRateMin = 2f;
	public float spawnRateMax = 4.5f;
	public float timeLeftForNextSpawn;

	public ObjectPool pool;

	void Awake()
	{
		ResetTimeForNextSpawn ();
		PoolConfiguration config = new PoolConfiguration
		{
			prefab = prefab,
			prefabTagName = "GreenHoop",
			poolSize = poolSize,
			initialPosition = GameConstants.poolStartPosition
		};
				
		pool = new ObjectPool (config);
	}

	// contains the logic of when this object should appear
	void Update() {
		if (GameController.instance.gameover)
		{
			return;
		}

		timeSinceLastSpawn += Time.deltaTime;

		if (TimeForNextSpawn())
		{
			timeSinceLastSpawn = 0;
			ResetTimeForNextSpawn ();

			float randomX = UnityEngine.Random.Range (GameConstants.minX, GameConstants.maxX);
			GameObject greenHoop = pool.BorrowFromPool();
			MoveChildren (greenHoop, new Vector2(randomX, GameConstants.spawnY));
		}
	}

	private bool TimeForNextSpawn() {
		return timeSinceLastSpawn >= timeLeftForNextSpawn;
	}

	private void ResetTimeForNextSpawn() {
		timeLeftForNextSpawn = UnityEngine.Random.Range (spawnRateMin, spawnRateMax);
	}

	private void MoveChildren(GameObject parent, Vector2 newPosition) {
		Vector2 bottomHoopPos = newPosition + new Vector2 (0, -.24f);
		foreach (Transform child in parent.transform) 
		{
			child.position = child.name.Equals ("BottomHoop") ? bottomHoopPos : newPosition;
		}
	}
}

