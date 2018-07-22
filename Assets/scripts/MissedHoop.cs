using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedHoop : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<WaveRider> () == null || GameController.instance.gameover) {
			return;
		}

		GameController.instance.LoseSpeed ();
	}
}
