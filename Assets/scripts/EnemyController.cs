using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameObject player;

	public float followPlayerDist = 5;
	private float attackRange = 1f;
	private float movementSpeed = 2.5f;

	private int direction = 1;

	private float playerDistance;

	private float moveForce = 365f;			// Amount of force added to move the player left and right.
	private float maxSpeed = 1f;				// The fastest the player can travel in the x axis.
	private bool standStill = false;
	private bool dropAhead = false;
	private bool blockedAhead = false;

	public GameObject fallCheckObject;
	public GameObject BlockCheckObject;

	public GameObject hand;
	public GameObject weapon;
	private Animator weaponAnim;

	[HideInInspector]
	public bool dead;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		weaponAnim = weapon.GetComponent<Animator> ();
	}

	void Update() {
		if (dead) {
			return;
		}

		Collider2D col = Physics2D.OverlapCircle (fallCheckObject.transform.position, 0.01f);
		dropAhead = col == null;

		col = Physics2D.OverlapCircle (BlockCheckObject.transform.position, 0.01f);
		blockedAhead = col != null;

		if (transform.localScale.x < 0) {
			hand.transform.localScale = new Vector2(-1,1);
		} else {
			hand.transform.localScale = new Vector2(1,1);
		}
	}

	void OnDead() {
		GetComponentInParent<Animator>().SetBool("dead", true);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 ();
		dead = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dead) {
			return;
		}

		playerDistance = Vector3.Distance (player.transform.position, transform.position);

		standStill = false;
		if (playerDistance < followPlayerDist) {
			if(playerDistance < attackRange) {
				standStill = true;
				Attack();
			} else {
				FollowPlayer();
			}
		} else {
			Patrol();
		}

		transform.localScale = new Vector2 (direction, 1);

		//move
		if (!standStill && !dropAhead) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2(movementSpeed * direction, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 ();
		}
	}

	void FollowPlayer() {
		if (player.transform.position.x < transform.position.x) {
			direction = -1;
		} else {
			direction = 1;
		}

		weaponAnim.SetBool ("attacking", false);
	}

	void Patrol() {
		if (dropAhead || blockedAhead) {
			direction *= -1;
		}

		weaponAnim.SetBool ("attacking", false);
	}

	void Attack() {
		weaponAnim.SetBool ("attacking", true);
	}


}
