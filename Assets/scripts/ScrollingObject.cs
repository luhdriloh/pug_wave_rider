using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
	public Rigidbody2D rigidBody;


	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity = new Vector2 (0, GameConstants.scrollingSpeed);
	}

	void Update () {
		// check if object is in view, if not we can stop it and let it chill
		if (GameController.instance.gameover) {
			rigidBody.velocity = Vector2.zero;
		}
			
		rigidBody.velocity = new Vector2 (0, GameConstants.scrollingSpeed);
	}
}
