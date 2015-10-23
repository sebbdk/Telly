using UnityEngine;
using System.Collections;

public class PlayerBodyController : MonoBehaviour {

	public void ShowReplay() {
		GameObject game = GameObject.Find ("GameController");
		game.GetComponent<Game> ().GameOver ();
	}

}
