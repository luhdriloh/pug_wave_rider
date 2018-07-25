using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Die", 2.5f);
	}
	
	// Update is called once per frame
	void Die () {
		Destroy (gameObject);
	}
}
