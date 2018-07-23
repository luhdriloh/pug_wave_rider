using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour {
	// Game speed
	public static float minScrollingSpeed = -4f;
	public static float scrollingSpeed = -4f;
	public static Vector2 poolStartPosition = new Vector2(0f, -20);
	public static float maxX = 2.37f;
	public static float minX = -2.37f;
	public static float spawnY = 10f;

	public static int pointPerHoop = 1000;

	public static float timeBetweenSpawns = .8f;
	public static System.DateTime timeOfLastSpawn = System.DateTime.UtcNow;
}
