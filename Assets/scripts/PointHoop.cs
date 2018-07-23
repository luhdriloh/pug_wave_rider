using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHoop : MonoBehaviour {
	public float speedIncrease;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<WaveRider> () == null || GameController.instance.gameover) {
			return;
		}

		float speedup = Random.Range (speedIncrease - .05f, speedIncrease + .02f);
		// score a point and increase the game speed
		float pointsScored = GetPointsScored ();
		GameController.instance.PlayerScored (pointsScored);
		GameController.instance.SetPoints (pointsScored);
		GameController.instance.PickUpSpeed(speedup);
	}

	private float GetPointsScored() {
		float bonus = (GameConstants.minScrollingSpeed - GameConstants.scrollingSpeed + .3f) / (.3f - (.25f - (16 - 4) / 12 * .25f));
		return Mathf.Ceil(GameConstants.pointPerHoop * bonus);
	}
}
