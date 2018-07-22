using System;
using UnityEngine;

public class BlueHoopPool : MonoBehaviour
{
	public int currentObstacle = 0;
	public int poolSize = 15;
	public GameObject prefab;
	public float timeSinceLastSpawn = 0;
	public float spawnRateMin = 12f;
	public float spawnRateMax = 30f;
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

		timeSinceLastSpawn += Time.deltaTime;

		if (TimeForNextSpawn())
		{
			timeSinceLastSpawn = 0;
			ResetTimeForNextSpawn ();

			CreateBlueHoopTunnel ();
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
		float hoopXPos = UnityEngine.Random.Range (GameConstants.minX, GameConstants.maxX);

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

