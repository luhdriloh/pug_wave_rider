using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour {
	public enum ArrowColor
	{
		Red,
		Green,
		Blue,
	}

	public static float arrowYPosition = 3.75f;
	public static float minScrollingSpeed = -4f;
	public static float scrollingSpeed = -4f;
	public static Vector2 poolStartPosition = new Vector2(0f, -20);
	public static float obstacleMaxX = 4.63f;
	public static float obstacleMinX = -4.63f;
	public static float hoopMaxX = 3.27f;
	public static float hoopMinX = -3.27f;
	public static float spawnY = 15f;

	public static int pointPerHoop = 1000;

	public static float timeBetweenSpawns = .8f;
	public static System.DateTime timeOfLastSpawn = System.DateTime.UtcNow;
}
