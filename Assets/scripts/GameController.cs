using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static GameController instance;
	public bool gameover = false;
	public float score = 0;
	public float currentPoints = 0;

	public Text bonusPointsText;
	public Text currentPointsText;
	public Text scoreText;
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
			GameConstants.scrollingSpeed = GameConstants.minScrollingSpeed;
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void PlayerDied() {
		gameover = true;
		gameOverText.SetActive (true);
	}

	public void PlayerScored(float points) {
		score += points;

		bonusPointsText.color = Color.red;
		currentPointsText.text = "Points: " + 0;
		scoreText.text = "Score: " + score;
	}

	public void PlayerCurrentPoints(float points) {
		currentPoints += points;
		currentPointsText.text = "Points: " + currentPoints;
	}

	public void PickUpSpeed() {
		Debug.Log ("speed: " + GameConstants.scrollingSpeed);
		GameConstants.scrollingSpeed -= .2f;
	}
		
	public void LoseSpeed() {
		GameConstants.scrollingSpeed = Mathf.Max (GameConstants.scrollingSpeed * .65f , GameConstants.minScrollingSpeed);
	}
}