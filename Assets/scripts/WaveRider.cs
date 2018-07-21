using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRider : MonoBehaviour {
	public Rigidbody2D rigidBody;
	public float horizontalMovement = 12f;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		// lets just move from right to left
		if (GameController.instance.gameover) {
			return;	
		}

		float x = Input.GetAxis("Horizontal");
		transform.position += new Vector3 (x, 0, 9) * horizontalMovement * Time.deltaTime;
	}
		
	void OnCollisionEnter2D(Collision2D other) {
		if (!other.gameObject.name.Equals("enemy", System.StringComparison.InvariantCultureIgnoreCase)) {
			return;
		}

		rigidBody.velocity = Vector2.zero;
		GameController.instance.PlayerDied ();
	}
}
