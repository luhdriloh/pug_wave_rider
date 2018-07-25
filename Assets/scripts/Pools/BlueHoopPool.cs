using System;
using UnityEngine;

public class BlueHoopPool : MonoBehaviour
{
	public int poolSize = 15;
	public GameObject prefab;
	public float timeSinceLastSpawn = 0;
	public float spawnRateMin = 10f;
	public float spawnRateMax = 25f;
	public float timeLeftForNextSpawn;

	private float hoopXVariability = .22f;
	private float distanceBetweenHoops = 1f;

	public ObjectPool pool;

	void Awake()
	{
		ResetTimeForNextSpawn ();
		PoolConfiguration config = new PoolConfiguration
		{
			prefab = prefab,
			prefabTagName = "BlueHoop",
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

		System.DateTime now = System.DateTime.UtcNow;
		double secondsSinceLastSpawn = (now - GameConstants.timeOfLastSpawn).TotalSeconds;

		if (secondsSinceLastSpawn < GameConstants.timeBetweenSpawns)
		{
			return;
		}
			
		timeSinceLastSpawn += Time.deltaTime;

		if (TimeForNextSpawn())
		{
			CreateBlueHoopTunnel ();
			GameController.instance.SetTimeOfLastSpawn (now + System.TimeSpan.FromSeconds(2.3));
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

	private void CreateBlueHoopTunnel()
	{
		float hoopYPos = GameConstants.spawnY;
		float hoopXPos = UnityEngine.Random.Range (GameConstants.hoopMinX, GameConstants.hoopMaxX);

		for (int i = 0; i < poolSize; i++)
		{
			GameObject blueHoop = pool.BorrowFromPool ();
			MoveChildren(blueHoop, new Vector2(hoopXPos, hoopYPos));
			hoopYPos += distanceBetweenHoops;
		}
	}
		

	private void MoveChildren(GameObject parent, Vector2 newPosition) {
		Vector2 bottomHoopPos = newPosition + new Vector2 (0, -.24f);
		foreach (Transform child in parent.transform) 
		{
			child.position = child.name.Equals ("BottomHoop") ? bottomHoopPos : newPosition;
		}
	}
}

