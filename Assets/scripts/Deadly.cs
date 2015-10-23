using UnityEngine;
using System.Collections;

public class Deadly : MonoBehaviour {

	public string targetTag = "EnemyHealth";
	public float damage = 1;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Equals(targetTag)) {
			collider.gameObject.SendMessage("OnDamage", damage);
		}
	}
}
