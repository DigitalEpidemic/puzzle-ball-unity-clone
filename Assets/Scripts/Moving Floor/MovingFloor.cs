using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {

	[SerializeField]
	private bool moveX, moveY, moveZ;

	[SerializeField]
	private float speed;

	void Update () {
		MovePlatform ();
	}

	void MovePlatform () {
		if (moveX) {
			Vector3 temp = transform.position;
			temp.x += speed * Time.deltaTime;
			transform.position = temp;
		}

		if (moveY) {
			Vector3 temp = transform.position;
			temp.y += speed * Time.deltaTime;
			transform.position = temp;
		}

		if (moveZ) {
			Vector3 temp = transform.position;
			temp.z += speed * Time.deltaTime;
			transform.position = temp;
		}
	}

	void OnTriggerEnter (Collider target) {
		if (target.tag == "Floor") {
			speed *= -1;
		}
	}

} // MovingFloor