using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BySecondPointUpdate : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (!GameController.instance.gameover) {
			GameController.instance.PlayerScored (-GameConstants.scrollingSpeed * 50f * Time.deltaTime);
		}
	}
}
