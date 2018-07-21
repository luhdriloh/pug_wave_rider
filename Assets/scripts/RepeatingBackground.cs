using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
	private float backgroundLength;

	// Use this for initialization
	void Start () {
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		backgroundLength = renderer.sprite.rect.height / renderer.sprite.pixelsPerUnit;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -backgroundLength) {
			transform.position += new Vector3 (0, 2 * backgroundLength, 0);
		}
	}
}
