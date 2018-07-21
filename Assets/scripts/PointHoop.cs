using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHoop : MonoBehaviour {
	public static float bonus = 1;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<WaveRider> () == null || GameController.instance.gameover) {
			return;
		}

		// score a point and increase the game speed
		GameController.instance.PickUpSpeed();
		GameController.instance.PlayerScored (GetPointsScored ());
	}

	private float GetPointsScored() {
		return GameConstants.pointPerHoop * PointHoop.bonus;
	}
}
