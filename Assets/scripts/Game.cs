using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GameObject replayBtn; 
	public GameObject PlayBtn;
	public GameObject player;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		player.SetActive (false);
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	public void Play () {
		Time.timeScale = 1;
		PlayBtn.SetActive (false);
		player.SetActive (true);
	}

	public void Reload () {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void GameOver () {
		replayBtn.SetActive (true);
		Time.timeScale = 0;
	}

	public void LateUpdate() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		int deathCount = 0;
		foreach (GameObject enemy in  enemies) {
			if(enemy.GetComponent<EnemyController>().dead) {
				deathCount++; 
			}
		}

		if (deathCount == enemies.Length) {
		//	GameOver ();
		}
	}

}
