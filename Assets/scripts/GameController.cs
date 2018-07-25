using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static GameController instance;
	public bool gameover = true;
	public float score = 0;
	public float currentPoints = 0;

	public Text speedText;
	public Text scoreText;
	public Text pointsText;
	public GameObject gameOverText;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Update() {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			gameover = false;
			GameConstants.scrollingSpeed = GameConstants.minScrollingSpeed;
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void PlayerDied() {
		gameover = true;
		gameOverText.SetActive (true);
	}

	public void PlayerScored(float points) {
		score += Mathf.Ceil(points);
		float bonus = ((Mathf.Pow (-GameConstants.scrollingSpeed, 1 + GameConstants.minScrollingSpeed - GameConstants.scrollingSpeed) / -GameConstants.scrollingSpeed) - 1) * 100;

		scoreText.text = "Score\n" + score;
	}

	public void SetPoints(float points) {
		pointsText.text = "Points\n" + points;
	}

	public void PickUpSpeed(float speed) {
		GameConstants.scrollingSpeed -= speed;
		Debug.Log ("speed: " + GameConstants.scrollingSpeed);
		speedText.text = "Speed\n" + Mathf.Ceil(GameConstants.scrollingSpeed * -50f) + "mph";
	}
		
	public void LoseSpeed() {
		GameConstants.scrollingSpeed = Mathf.Min (GameConstants.scrollingSpeed * .7f , GameConstants.minScrollingSpeed);
		speedText.text = "Speed\n" + Mathf.Ceil(GameConstants.scrollingSpeed * -50f) + "mph";
	}

	public void SetTimeOfLastSpawn(System.DateTime time) {
		GameConstants.timeOfLastSpawn = time;
	}
}