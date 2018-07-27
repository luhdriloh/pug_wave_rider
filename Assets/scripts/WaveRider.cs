using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRider : MonoBehaviour {
	public GameObject explosion;
	public Rigidbody2D rigidBody;
	public float horizontalMovement = 6f;
	public float tiltAngle = 25.0f;
	public float smooth = 5f;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		// lets just move from right to left
		if (GameController.instance.gameover) {
			return;	
		}

		if (GameConstants.scrollingSpeed <= -16) {
			horizontalMovement = 11f;
		}
		else if (GameConstants.scrollingSpeed <= -10)
		{
			horizontalMovement = 9f;
		}
		else
		{
			horizontalMovement = 6f;
		}

		float x = Input.GetAxis("Horizontal");

		// Dampen towards the target rotation
		Quaternion target = Quaternion.Euler(0, 0, x * -tiltAngle);
		transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);

		transform.position += new Vector3 (x, 0, 0) * horizontalMovement * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (!other.gameObject.name.Equals("Missile", System.StringComparison.InvariantCultureIgnoreCase)) {
			return;
		}


		rigidBody.velocity = Vector2.zero;
		GameController.instance.PlayerDied ();
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (other.gameObject);
		gameObject.SetActive (false);
	}
}
