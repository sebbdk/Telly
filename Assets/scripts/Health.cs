using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth = 1;
	public float currentHealth = 1;

	public bool dead;

	public GameObject healthLine;

	void Update() {
		healthLine.transform.localScale = new Vector2 (currentHealth/maxHealth, 1);
	}

	void OnDamage(float damage) {
		currentHealth -= damage;

		if (currentHealth < 0) {
			currentHealth = 0;
		}

		if (!dead && currentHealth <= 0) {
			currentHealth = 0;
			transform.parent.SendMessage("OnDead");
			dead = true;
		}
	}
}
