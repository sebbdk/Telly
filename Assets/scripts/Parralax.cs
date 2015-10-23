using UnityEngine;
using System.Collections;

public class Parralax : MonoBehaviour {

	public GameObject player;
	public float xTresh = 10;
	public float yTresh = 6;

	private Vector2 startOffset;

	void Start() {
		startOffset = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate  () {
		if (player) {

			Vector3 b = player.transform.position;
			b.y = 0;
			b.x = b.x / xTresh;

			Vector3 p = player.transform.position;
			p.y = startOffset.y - p.y / yTresh;

			transform.position = p - b;
		}
	}

}
