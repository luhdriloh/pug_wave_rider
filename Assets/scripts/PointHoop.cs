using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHoop : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<WaveRider> () == null || GameController.instance.gameover) {
			return;
		}

		// score a point and increase the game speed
		GameController.instance.PlayerScored (Mathf.Ceil(GetPointsScored ()));
		GameController.instance.PickUpSpeed();
	}

	private float GetPointsScored() {
		return GameConstants.pointPerHoop * (1 + GameConstants.minScrollingSpeed - GameConstants.scrollingSpeed);
	}
}
