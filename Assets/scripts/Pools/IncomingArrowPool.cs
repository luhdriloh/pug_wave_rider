using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingArrowPool : MonoBehaviour
{
	public int poolSize = 5;
	public GameObject redArrowPrototype;
	public GameObject greenArrowPrototype;
	public GameObject blueArrowPrototype;

	private ObjectPool redArrowPool;
	private ObjectPool blueArrowPool;
	private ObjectPool greenArrowPool;

	public Dictionary<GameConstants.ArrowColor, ObjectPool> arrowColorToPoolMap;

	void Awake ()
	{
		PoolConfiguration redArrowConfig = new PoolConfiguration
		{
			prefab = redArrowPrototype,
			prefabTagName = "RedArrow",
			poolSize = poolSize,
			initialPosition = GameConstants.poolStartPosition
		};

		PoolConfiguration blueArrowConfig = new PoolConfiguration
		{
			prefab = blueArrowPrototype,
			prefabTagName = "BlueArrow",
			poolSize = poolSize,
			initialPosition = GameConstants.poolStartPosition
		};

		PoolConfiguration greenArrowConfig = new PoolConfiguration
		{
			prefab = greenArrowPrototype,
			prefabTagName = "GreenArrow",
			poolSize = poolSize,
			initialPosition = GameConstants.poolStartPosition
		};

		redArrowPool = new ObjectPool (redArrowConfig);
		greenArrowPool = new ObjectPool (greenArrowConfig);
		blueArrowPool = new ObjectPool (blueArrowConfig);

		arrowColorToPoolMap = new Dictionary<GameConstants.ArrowColor, ObjectPool> () {
			{ GameConstants.ArrowColor.Red, redArrowPool },
			{ GameConstants.ArrowColor.Blue, blueArrowPool },
			{ GameConstants.ArrowColor.Green, greenArrowPool }
		};
	}

	public void SetArrow(GameConstants.ArrowColor arrowColor, Transform other)
	{
		GameObject arrow = arrowColorToPoolMap [arrowColor].BorrowFromPool ();
		arrow.GetComponent<DistanceMeter> ().SetMeter(other);
		arrow.transform.position = new Vector2 (other.position.x, GameConstants.arrowYPosition);
	}
}

