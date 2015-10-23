using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	private Camera camera;

	public float mapX = 100f;
	public float mapY = 100f;
	
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();

		float vertExtent = camera.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;

		// Calculations assume map is position at the origin
		minX = horzExtent;
		maxX = mapX - horzExtent;
		minY = mapY + vertExtent;
		maxY = vertExtent;
	}

	void LateUpdate() {

	}
	
	// Update is called once per frame
	void FixedUpdate  () {
		float vertExtent = camera.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;
		
		// Calculations assume map is position at the origin
		minX = horzExtent;
		maxX = mapX - horzExtent;
		minY = mapY + vertExtent;
		maxY = vertExtent;

		if (player) {
			Vector3 point = camera.WorldToViewportPoint(player.transform.position);
			Vector3 delta = player.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));


			Vector3 destination = transform.position + delta;
			destination.x = Mathf.Clamp(destination.x, minX, maxX);
			destination.y = Mathf.Clamp(destination.y, minY, maxY);

			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);



			//transform.position = destination;
		}
	}
}
